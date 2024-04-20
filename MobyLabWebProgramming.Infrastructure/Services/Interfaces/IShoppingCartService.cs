﻿using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    internal interface IShoppingCartService
    {

        public Task<ServiceResponse<ShoppingCartDTO>> GetShoppingCart(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<PagedResponse<ShoppingCartDTO>>> GetShoppingCarts(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
        //public Task<ServiceResponse> AddShoppingCart(ShoppingCartAddDTO shoppingCart, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> UpdateShoppingCart(ShoppingCartUpdateDTO shoppingCart, CancellationToken cancellationToken = default);
        public Task<ServiceResponse> DeleteShoppingCart(Guid id, CancellationToken cancellationToken = default);
    }
}