using MobyLabWebProgramming.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class OrderPlaceDTO
    {
        public ShippingMethod ShippingMethod { get; set; } = default!;
        public PaymentMethod PaymentMethod { get; set; } = default!;
    }
}
