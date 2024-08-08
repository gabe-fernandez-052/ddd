using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using WarehouseManagement.API.Constants;
using WarehouseManagement.API.Responses;
using WarehouseManagement.Infrastructure.Models;

namespace WarehouseManagement.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableRateLimiting(RateLimitConstants.FIXED_POLICY)]
    public class IdentityController(IConfiguration config) : Controller
    {
        [HttpPost("token/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<string>))]
        public IActionResult GenerateToken(Guid clientId)
        {
            var response = new Response<string>();
            var user = config.GetSection("Users").Get<List<User>>()?.SingleOrDefault(x => x.ClientId == clientId);

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();

                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                claims.Add(new Claim(ClaimTypes.Sid, user.ClientId.ToString()));

                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                                                 config["Jwt:Audience"],
                                                 claims,
                                                 expires: DateTime.Now.AddHours(1),
                                                 signingCredentials: credentials);

                response.Content = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(response);
            }

            response.Error = "Client id not found";

            return NotFound(response);
        }
    }
}
