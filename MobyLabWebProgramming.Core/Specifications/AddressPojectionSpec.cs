using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;


namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class AddressPojectionSpec : BaseSpec<AddressPojectionSpec, Address, AddressDTO>
    {
        protected override Expression<Func<Address, AddressDTO>> Spec => e => new()
        {
            Id = e.Id,
            Street = e.Street,
            City = e.City,
            State = e.State,
            Country = e.Country,
            PostalCode = e.PostalCode,
            Number = e.Number,
            User = new UserDTO
            {
                Id = e.User.Id,
                Email = e.User.Email,
                Name = e.User.Name,
                Role = e.User.Role
            }
        };

        public AddressPojectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }

        public AddressPojectionSpec(Guid id) : base(id)
        {
        }

        public AddressPojectionSpec(string? search)
        {
            search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

            if (search == null)
            {
                return;
            }

            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.Street, searchExpr));
        }
    }
}
