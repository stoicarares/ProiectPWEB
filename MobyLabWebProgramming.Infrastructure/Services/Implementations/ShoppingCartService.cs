using System.Net;
using MobyLabWebProgramming.Core.Constants;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public ShoppingCartService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ShoppingCartDTO>> GetShoppingCart(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new ShoppingCartProjectionSpec(id), cancellationToken);
            return result != null ?
                ServiceResponse<ShoppingCartDTO>.ForSuccess(result) :
                ServiceResponse<ShoppingCartDTO>.FromError(CommonErrors.ShoppingCartNotFound);
        }

        /*public async Task<ServiceResponse<PagedResponse<ShoppingCartDTO>>> GetShoppingCarts(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new ShoppingCartProjectionSpec(pagination.Search), cancellationToken);
            return ServiceResponse<PagedResponse<ShoppingCartDTO>>.ForSuccess(result);
        }*/

        public async Task<ServiceResponse> AddToShoppingCart(ShoppingCartAddDTO shoppingCart, CancellationToken cancellationToken = default)
        {
            var existingCart = await _repository.GetAsync(new ShoppingCartSpec(shoppingCart.UserId), cancellationToken);

            if (existingCart != null)
            {
                var product = await _repository.GetAsync<Product>(shoppingCart.ProductId, cancellationToken);
                if (product == null)
                {
                    return ServiceResponse.FromError(CommonErrors.ProductNotFound);
                }

                existingCart.Products.Add(product);
                await _repository.UpdateAsync(existingCart, cancellationToken);
            }
            else
            {
                var product = await _repository.GetAsync<Product>(shoppingCart.ProductId, cancellationToken);
                if (product == null)
                {
                    return ServiceResponse.FromError(CommonErrors.ProductNotFound);
                }

                var newShoppingCart = new ShoppingCart
                {
                    UserId = shoppingCart.UserId,
                    Products = new List<Product> { product },
                    TotalPrice = product.Price * product.Quantity // Assuming initial total price is the price of the added product
                };

                await _repository.AddAsync(newShoppingCart, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateShoppingCart(ShoppingCartUpdateDTO shoppingCart, CancellationToken cancellationToken = default)
        {
            var existingCart = await _repository.GetAsync(new ShoppingCartSpec(shoppingCart.UserId), cancellationToken);

            if (existingCart != null)
            {
                existingCart.TotalPrice += shoppingCart.TotalPrice.HasValue ? shoppingCart.TotalPrice.Value : 0;
                await _repository.UpdateAsync(existingCart, cancellationToken);
                return ServiceResponse.ForSuccess();
            }

            return ServiceResponse.FromError(CommonErrors.ShoppingCartNotFound);
        }

        public async Task<ServiceResponse> DeleteShoppingCart(Guid id, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync<ShoppingCart>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }
    }
}
