using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ShoppingCartSpec : BaseSpec<ShoppingCartSpec, ShoppingCart>
    {
        public ShoppingCartSpec(Guid id) : base(id)
        {
        }

        public ShoppingCartSpec(User user)
        {
            Query.Where(e => e.User.Id == user.Id);
        }
    }
}
