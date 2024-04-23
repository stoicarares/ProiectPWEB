using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class OrderProjectionSpec : BaseSpec<OrderProjectionSpec, Order, OrderDTO>
    {
        protected override Expression<Func<Order, OrderDTO>> Spec => e => new()
        {
            Id = e.Id,
            ShippingMethod = e.ShippingMethod,
            PaymentMethod = e.PaymentMethod,
            ShoppingCart = new ShoppingCartDTO
            {
                Id = e.ShoppingCart.Id,
                User = new UserDTO
                {
                    Id = e.ShoppingCart.User.Id,
                    Email = e.ShoppingCart.User.Email,
                    Name = e.ShoppingCart.User.Name,
                    Role = e.ShoppingCart.User.Role
                }
            }
        };

        public OrderProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }
        public OrderProjectionSpec(Guid id) : base(id)
        {
        }
    }
}
