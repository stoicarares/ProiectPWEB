using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<ServiceResponse<ReviewDTO>> GetReview(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<PagedResponse<ReviewDTO>>> GetReviews(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> AddReview(ReviewAddDTO review, Guid userId, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> UpdateReview(ReviewUpdateDTO review, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DeleteReview(Guid id, CancellationToken cancellationToken = default);
    }
}
