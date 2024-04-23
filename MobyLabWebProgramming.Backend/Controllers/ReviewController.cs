using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;


namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReviewController : AuthorizedController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService, IUserService userService) : base(userService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<ReviewDTO>>> GetById(Guid id)
        {
            return this.FromServiceResponse(await _reviewService.GetReview(id));
        }

        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<ReviewDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
        {
            return this.FromServiceResponse(await _reviewService.GetReviews(pagination));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] ReviewAddDTO review)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _reviewService.AddReview(review, currentUser.Result.Id)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] ReviewUpdateDTO review)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _reviewService.UpdateReview(review)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete(Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _reviewService.DeleteReview(id)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }
}
