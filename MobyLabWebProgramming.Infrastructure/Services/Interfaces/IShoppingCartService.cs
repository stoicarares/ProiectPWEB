using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IShoppingCartService
    {

        public Task<ServiceResponse<ShoppingCartDTO>> GetShoppingCart(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> AddToShoppingCart(ShoppingCartAddDTO shoppingCart, Guid shoppingCartId, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> UpdateShoppingCart(ShoppingCartUpdateDTO shoppingCart, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DeleteShoppingCart(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> ClearShoppingCart(Guid userId, CancellationToken cancellationToken = default);
    }
}
