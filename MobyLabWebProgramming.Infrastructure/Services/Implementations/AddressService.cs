using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System.Net;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public AddressService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse> AddAddress(AddressAddDTO address, Guid userId, CancellationToken cancellation = default)
        {
            await _repository.AddAsync(new Address
            {
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
                UserId = userId
            }, cancellation);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteAddress(Guid id, CancellationToken cancellation = default)
        {
            await _repository.DeleteAsync<Address>(id, cancellation);
            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse<AddressDTO>> GetAddress(Guid id, CancellationToken cancellation = default)
        {
            var result = await _repository.GetAsync(new AddressPojectionSpec(id), cancellation);
            return result != null ?
                ServiceResponse<AddressDTO>.ForSuccess(result) :
                ServiceResponse<AddressDTO>.FromError(CommonErrors.AddressNotFound);
        }

        public async Task<ServiceResponse> UpdateAddress(AddressUpdateDTO address, CancellationToken cancellation = default)
        {
            var entity = await _repository.GetAsync(new AddressSpec(address.id), cancellation);
            if (entity != null)
            {
                entity.Street = address.Street ?? entity.Street;
                entity.Number = address.Number ?? entity.Number;
                entity.City = address.City ?? entity.City;
                entity.State = address.State ?? entity.State;
                entity.Country = address.Country ?? entity.Country;
                entity.PostalCode = address.PostalCode ?? entity.PostalCode;

                await _repository.UpdateAsync(entity, cancellation);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
