using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = default!;
        public int Number { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public UserDTO User { get; set; } = default!;
    }
}
