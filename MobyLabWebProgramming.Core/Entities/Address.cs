using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } = default!;
        public int Number { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
