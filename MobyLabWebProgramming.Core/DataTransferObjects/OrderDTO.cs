using MobyLabWebProgramming.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public ShippingMethod ShippingMethod { get; set; } = default!;
        public PaymentMethod PaymentMethod { get; set; } = default!;
        public ShoppingCartDTO ShoppingCart { get; set; } = default!;

    }
}
