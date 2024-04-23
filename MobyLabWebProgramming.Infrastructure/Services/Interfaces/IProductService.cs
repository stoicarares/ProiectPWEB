﻿using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;


namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ServiceResponse<ProductDTO>> GetProduct(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<PagedResponse<ProductDTO>>> GetProducts(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> AddProduct(ProductAddDTO product, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> UpdateProduct(ProductUpdateDTO product, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DeleteProduct(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DecreaseStock(Guid productId, int quantity, CancellationToken cancellationToken = default);

    }
}
