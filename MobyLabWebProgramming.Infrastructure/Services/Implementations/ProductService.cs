using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public ProductService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ProductDTO>> GetProduct(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new ProductProjectionSpec(id), cancellationToken);
            return result != null ?
                ServiceResponse<ProductDTO>.ForSuccess(result) :
                ServiceResponse<ProductDTO>.FromError(CommonErrors.ProductNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<ProductDTO>>> GetProducts(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new ProductProjectionSpec(pagination.Search), cancellationToken);
            return ServiceResponse<PagedResponse<ProductDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse> AddProduct(ProductAddDTO product, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Image = product.Image,
                Quantity = product.Quantity
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateProduct(ProductUpdateDTO product, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(new ProductSpec(product.Id), cancellationToken);

            if (entity != null)
            {
                entity.Name = product.Name ?? entity.Name;
                entity.Description = product.Description ?? entity.Description;
                entity.Price = product.Price ?? entity.Price;
                entity.Stock = product.Stock ?? entity.Stock;
                entity.Image = product.Image ?? entity.Image;
                entity.Quantity = product.Quantity ?? entity.Quantity;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteProduct(Guid id, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync<Product>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }
    }
}
