using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;


namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IAddressService
    {
        public Task<ServiceResponse> AddAddress(AddressAddDTO address, Guid userId, CancellationToken cancellation = default);
        public Task<ServiceResponse<AddressDTO>> GetAddress(Guid id, CancellationToken cancellation = default);
        public Task<ServiceResponse> UpdateAddress(AddressUpdateDTO address, CancellationToken cancellation = default);
        public Task<ServiceResponse> DeleteAddress(Guid id, CancellationToken cancellation = default);

    }
}
