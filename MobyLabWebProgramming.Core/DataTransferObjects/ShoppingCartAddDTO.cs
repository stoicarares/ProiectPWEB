using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class ShoppingCartAddDTO
    {
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
