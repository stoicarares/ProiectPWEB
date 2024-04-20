using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;


namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ReviewProjectionSpec : BaseSpec<ReviewProjectionSpec, Review, ReviewDTO>
    {
        protected override Expression<Func<Review, ReviewDTO>> Spec => e => new()
        {
            Id = e.Id,
            Rating = e.Rating,
            Content = e.Content,
            Title = e.Title,
            ReviewedProduct = new ProductDTO
            {
                Id = e.ReviewedProductId,
                Name = e.ReviewedProduct.Name,
                Description = e.ReviewedProduct.Description,
                Price = e.ReviewedProduct.Price,
                Stock = e.ReviewedProduct.Stock,
                Image = e.ReviewedProduct.Image,
                Quantity = e.ReviewedProduct.Quantity
            },
            User = new UserDTO
            {
                Id = e.UserId,
                Name = e.User.Name,
                Email = e.User.Email,
                Role = e.User.Role
            }
        };

        public ReviewProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }

        public ReviewProjectionSpec(Guid id) : base(id)
        {
        }

        public ReviewProjectionSpec(string? search)
        {
            search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

            if (search == null)
            {
                return;
            }

            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.Title, searchExpr));
        }
    }
}
