using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;


namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ReviewSpec : BaseSpec<ReviewSpec, Review>
    {
        public ReviewSpec(Guid id) : base(id)
        {
        }

        public ReviewSpec(User user)
        {
            Query.Where(e => e.User.Id == user.Id);
        }
    }
}
