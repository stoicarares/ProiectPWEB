namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public record AddressUpdateDTO(Guid id, string? Street, int? Number, string? City, string? State, string? Country, string? PostalCode);
}
