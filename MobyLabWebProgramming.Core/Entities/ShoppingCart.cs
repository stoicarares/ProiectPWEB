using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public ICollection<Product> Products { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }

    }
}
