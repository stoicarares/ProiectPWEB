using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; } = default!;
        public int Quantity { get; set; } = default!;

        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = default!;
        public ICollection<Review> Reviews { get; set; } = default!;
    }
}
