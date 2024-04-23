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
using MobyLabWebProgramming.Infrastructure.Repositories.Implementation;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;


namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;
        private readonly IMailService _mailService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;

        public OrderService(IRepository<WebAppDatabaseContext> repository, IMailService mailService, IShoppingCartService shoppingCartService, IProductService productService)
        {
            _repository = repository;
            _mailService = mailService;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }

        public async Task<ServiceResponse<OrderDTO>> GetOrder(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(new OrderProjectionSpec(Id), cancellationToken);
            return result != null ?
                ServiceResponse<OrderDTO>.ForSuccess(result) :
                ServiceResponse<OrderDTO>.FromError(CommonErrors.OrderNotFound);
        }

        public async Task<ServiceResponse> PlaceOrder(OrderPlaceDTO orderPlaceDTO, Guid shoppingCartId, string userEmail, string userName, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(shoppingCartId, cancellationToken);
            if (shoppingCart.Result == null)
            {
                return ServiceResponse.FromError(CommonErrors.ShoppingCartNotFound);
            }

            if (shoppingCart.Result.Products.Count == 0)
            {
                return ServiceResponse.FromError(CommonErrors.ShoppingCartEmpty);
            }

            var order = new Order
            {
                ShoppingCartId = shoppingCartId,
                PaymentMethod = orderPlaceDTO.PaymentMethod,
                ShippingMethod = orderPlaceDTO.ShippingMethod
            };

            await _repository.AddAsync(order, cancellationToken);

            foreach (var product in shoppingCart.Result.Products)
            {
                await _productService.DecreaseStock(product.Id, (int) (shoppingCart.Result.TotalPrice / product.Price), cancellationToken);
            }

            await _shoppingCartService.DeleteShoppingCart(shoppingCartId, cancellationToken); // Delete the shopping cart after placing the order

            await _mailService.SendMail(userEmail, "Order from My App", MailTemplates.OrderCompletionTemplate(userName), true, "My App", cancellationToken); // You can send a notification on the user email. Change the email if you want.

            return ServiceResponse.ForSuccess();
        }
        public async Task<ServiceResponse> DeleteOrder(Guid Id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(new OrderSpec(Id), cancellationToken);
            return ServiceResponse.ForSuccess();
        }
    }
}
