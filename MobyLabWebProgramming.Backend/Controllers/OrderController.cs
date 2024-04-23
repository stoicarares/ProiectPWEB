using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : AuthorizedController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, IUserService userService) : base(userService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<OrderDTO>>> GetById(Guid id)
        {
            return this.FromServiceResponse(await _orderService.GetOrder(id));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> PlaceOrder([FromBody] OrderPlaceDTO order)
        {
            var currentUser = await GetCurrentUser();

            var currentUserResult = currentUser.Result;
            return currentUserResult != null ?
               this.FromServiceResponse(await _orderService.PlaceOrder(order, currentUserResult.ShoppingCart.Id, currentUserResult.Email, currentUserResult.Name)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete(Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _orderService.DeleteOrder(id)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }
}
