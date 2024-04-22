using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
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
    public class ProductController : AuthorizedController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IUserService userService) : base(userService)
        {
            _productService = productService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<ProductDTO>>> GetById(Guid id)
        {
            return this.FromServiceResponse(await _productService.GetProduct(id));
        }

        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<ProductDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            return this.FromServiceResponse(await _productService.GetProducts(pagination));
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] ProductAddDTO product)
        {
            return this.FromServiceResponse(await _productService.AddProduct(product));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] ProductUpdateDTO product)
        {
            return this.FromServiceResponse(await _productService.UpdateProduct(product));
            //return this.ErrorMessageResult(CommonErrors.Unauthorized);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete(Guid id)
        {
           /* var currentUser = await GetCurrentUser();
            if (currentUser.Result != null && currentUser.Result.Role == UserRoleEnum.Admin)
            {*/
            return this.FromServiceResponse(await _productService.DeleteProduct(id));
            //}

            //return this.ErrorMessageResult(CommonErrors.Unauthorized);
        }
    }
}
