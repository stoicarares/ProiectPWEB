using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class OrderSpec : BaseSpec<OrderSpec, Order>
    {
        public OrderSpec(Guid id) : base(id)
        {
        }
    }
}
