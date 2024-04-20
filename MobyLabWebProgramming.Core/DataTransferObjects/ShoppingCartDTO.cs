using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public UserDTO User { get; set; } = default!;
    }
}
