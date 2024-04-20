using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int Rating { get; set; }
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }
        public Product ReviewedProduct { get; set; } = default!;
        public Guid ReviewedProductId { get; set; }
    }
}
