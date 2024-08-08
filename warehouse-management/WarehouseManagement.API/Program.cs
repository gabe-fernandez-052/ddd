using System.Net;
using System.Text;
using System.Threading.RateLimiting;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using WarehouseManagement.API.Constants;
using WarehouseManagement.API.Responses;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.Services;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using WarehouseManagement.Infrastructure.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
var builderConfig = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "WarehouseManagement.API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = JwtConstants.TokenType,
        Scheme = JwtBearerDefaults.AuthenticationScheme.ToLower()
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builderConfig["Jwt:Issuer"],
        ValidAudience = builderConfig["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builderConfig["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddDbContext<WarehouseManagementContext>(options =>
{
    options.UseSqlServer(builderConfig.GetConnectionString("DbConnectionString"));

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

builder.Services.AddScoped<IReceivingService>(service => new ReceivingService(new ReceivingUnitOfWork(service.GetRequiredService<WarehouseManagementContext>())));

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

builder.Services.AddOpenTelemetry()
                .WithMetrics(builder =>
                {
                    builder.AddAspNetCoreInstrumentation();
                    builder.AddHttpClientInstrumentation();
                })
                .WithTracing(builder =>
                {
                    builder.AddAspNetCoreInstrumentation();
                    builder.AddHttpClientInstrumentation();
                })
                .UseAzureMonitor();

builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy(RateLimitConstants.FIXED_POLICY, httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                                                 factory: _ => new FixedWindowRateLimiterOptions()
                                                 {
                                                     PermitLimit = 30,
                                                     Window = TimeSpan.FromSeconds(30)
                                                 }));

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

builder.Services.AddHealthChecks()
                .AddSqlServer(builderConfig.GetConnectionString("DbConnectionString")!)
                .AddDbContextCheck<WarehouseManagementContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseManagement.API");
    options.RoutePrefix = string.Empty;
});

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            var baseException = contextFeature.Error?.GetBaseException();
            var errorMessage = !string.IsNullOrEmpty(baseException?.Message) ? baseException.Message : "Something went wrong. Please try again in a few minutes.";
            var logger = app.Services.GetRequiredService<ILogger<Program>>();

            logger.LogError(errorMessage);

            await context.Response.WriteAsJsonAsync(new Response<object>() { Content = null, Error = errorMessage });
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpLogging();

app.UseRateLimiter();

app.MapControllers();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
