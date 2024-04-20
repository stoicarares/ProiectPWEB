using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
   public record ProductUpdateDTO(Guid Id, string? Name, string? Description, decimal? Price, int? Stock, string? Image, int? Quantity);
}
