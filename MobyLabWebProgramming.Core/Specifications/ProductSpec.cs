﻿using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class ProductSpec : BaseSpec<ProductSpec, Product>
    {
        public ProductSpec(Guid id) : base(id)
        {
        }

        public ProductSpec(string name)
        {
            Query.Where(e => e.Name == name);
        }
    }
}
