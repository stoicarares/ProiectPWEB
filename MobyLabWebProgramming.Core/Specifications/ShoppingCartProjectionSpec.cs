using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ShoppingCartProjectionSpec : BaseSpec<ShoppingCartProjectionSpec, ShoppingCart, ShoppingCartDTO>
    {
        protected override Expression<Func<ShoppingCart, ShoppingCartDTO>> Spec => e => new()
        {
            Id = e.Id,
            TotalPrice = e.TotalPrice,
            Products = e.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Image = p.Image,
                Quantity = p.Quantity
            }).ToList(),
            User = new UserDTO
            {
                Id = e.UserId,
                Name = e.User.Name,
                Email = e.User.Email,
                Role = e.User.Role
            }
        };

        public ShoppingCartProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }

        public ShoppingCartProjectionSpec(Guid id) : base(id)
        {
        }

        public ShoppingCartProjectionSpec(Guid userId, bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
            Query.Where(e => e.UserId == userId);
        }


    }

}
