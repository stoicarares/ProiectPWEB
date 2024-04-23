using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class AddressSpec : BaseSpec<AddressSpec, Address>
    {
        public AddressSpec(Guid id) : base(id)
        {
        }
    }
}
