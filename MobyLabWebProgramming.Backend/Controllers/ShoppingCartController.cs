using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShoppingCartController : AuthorizedController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IUserService userService) : base(userService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<ShoppingCartDTO>>> Get(Guid id)
        {
            var currentUser = await GetCurrentUser();
            if (currentUser.Result != null)
            {
                return this.FromServiceResponse(await _shoppingCartService.GetShoppingCart(id));
            }

            return this.ErrorMessageResult<ShoppingCartDTO>(CommonErrors.UserNotFound);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] ShoppingCartAddDTO item)
        {
            var currentUser = await GetCurrentUser();
            if (currentUser.Result != null && (currentUser.Result.Id == item.UserId || currentUser.Result.Role == UserRoleEnum.Admin))
            {
                return this.FromServiceResponse(await _shoppingCartService.AddToShoppingCart(item));
            }

            return this.ErrorMessageResult(CommonErrors.UserNotFound);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] ShoppingCartUpdateDTO item)
        {
            var currentUser = await GetCurrentUser();
            if (currentUser.Result != null && currentUser.Result.Id == item.UserId)
            {
                return this.FromServiceResponse(await _shoppingCartService.UpdateShoppingCart(item));
            }

            return this.ErrorMessageResult(CommonErrors.UserNotFound);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete(Guid id)
        {
            return this.FromServiceResponse(await _shoppingCartService.DeleteShoppingCart(id));
        }
    }
}
