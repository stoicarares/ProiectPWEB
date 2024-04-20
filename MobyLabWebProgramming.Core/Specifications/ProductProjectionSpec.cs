using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;


namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ProductProjectionSpec : BaseSpec<ProductProjectionSpec, Product, ProductDTO>
    {
        protected override Expression<Func<Product, ProductDTO>> Spec => e => new()
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Price = e.Price,
            Stock = e.Stock,
            Image = e.Image,
            Quantity = e.Quantity,
            Reviews = e.Reviews.Select(r => new ReviewDTO
            {
                Id = r.Id,
                Rating = r.Rating,
                Content = r.Content,
                Title = r.Title,
                ReviewedProduct = new ProductDTO
                {
                    Id = r.ReviewedProductId,
                    Name = r.ReviewedProduct.Name,
                    Description = r.ReviewedProduct.Description,
                    Price = r.ReviewedProduct.Price,
                    Stock = r.ReviewedProduct.Stock,
                    Image = r.ReviewedProduct.Image,
                    Quantity = r.ReviewedProduct.Quantity
                },
                User = new UserDTO
                {
                    Id = r.UserId,
                    Name = r.User.Name,
                    Email = r.User.Email,
                    Role = r.User.Role
                }
                
            }).ToList()
        };

        public ProductProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }

        public ProductProjectionSpec(Guid id) : base(id)
        {
        }

        public ProductProjectionSpec(string? search)
        {
            search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

            if (search == null)
            {
                return;
            }

            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.Name, searchExpr));
        }
    }
}
