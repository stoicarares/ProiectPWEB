using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public record ShoppingCartUpdateDTO(Guid Id, Guid UserId, decimal? TotalPrice);
}
