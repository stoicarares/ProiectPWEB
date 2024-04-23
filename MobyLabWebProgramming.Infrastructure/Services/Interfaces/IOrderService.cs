using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ServiceResponse<OrderDTO>> GetOrder(Guid Id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> PlaceOrder(OrderPlaceDTO orderPlaceDTO, Guid shoppingCartId, string userEmail, string userName, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DeleteOrder(Guid Id, CancellationToken cancellationToken = default);
    }
}
