using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WarehouseManagement.API.Constants;
using WarehouseManagement.API.Requests;
using WarehouseManagement.API.Responses;
using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.ValueObjects;

namespace WarehouseManagement.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableRateLimiting(RateLimitConstants.FIXED_POLICY)]
    public class ReceivingController(ILogger<ReceivingController> logger, IReceivingService receivingService) : ControllerBase
    {
        [HttpPost("receive")]
        [Authorize(Roles = RoleConstants.USER_ROLE)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ReceiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<object>))]
        public IActionResult Receive(ReceiveRequestDto requestDto)
        {
            var response = new Response<ReceiveResponseDto>();

            try
            {
                var clientId = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

                var itemsToReceive = new List<ReceiveItem>(requestDto.Items.Select(i =>
                                                              new ReceiveItem(i.PartNumber, i.Quantity, i.LotCode, i.DateCode, i.LocationInfo, i.ThirdPartyReference, i.DateReceived)));

                var receiver = receivingService.Receive(requestDto.SupplierOrderNumber, new Guid(clientId), requestDto.WarehouseNumber,
                                                              requestDto.TrackingNumber, requestDto.InvoiceNumber, requestDto.PackingListNumber, itemsToReceive);

                response.Content = new ReceiveResponseDto(receiver);
                return Ok(response);
            }
            catch (ReceivingException e)
            {
                logger.LogError(e.Message);
                response.Error = e.Message;

                return BadRequest(response);
            }
        }
    }
}
