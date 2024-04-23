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
    public class ReviewService : IReviewService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public ReviewService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ReviewDTO>> GetReview(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new ReviewProjectionSpec(id), cancellationToken);
            return result != null ?
                ServiceResponse<ReviewDTO>.ForSuccess(result) :
                ServiceResponse<ReviewDTO>.FromError(CommonErrors.ReviewNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<ReviewDTO>>> GetReviews(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new ReviewProjectionSpec(pagination.Search), cancellationToken);
            return ServiceResponse<PagedResponse<ReviewDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse> AddReview(ReviewAddDTO review, Guid userId, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(new Review
            {
                Title = review.Title,
                Content = review.Content,
                Rating = review.Rating,
                UserId = userId,
                ReviewedProductId = review.ProductId,
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateReview(ReviewUpdateDTO review, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(new ReviewSpec(review.Id), cancellationToken);
            if (entity != null)
            {
                entity.Title = review.Title ?? entity.Title;
                entity.Content = review.Content ?? entity.Content;
                entity.Rating = review.Rating ?? entity.Rating;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteReview(Guid id, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync<Review>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }
    }
}
