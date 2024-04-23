using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Order : BaseEntity
    {
        public ShoppingCart ShoppingCart { get; set; } = default!;
        public Guid ShoppingCartId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = default!;
        public ShippingMethod ShippingMethod { get; set; } = default!;
    }
}
