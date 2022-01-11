﻿using Ardalis.Specification;
using DN.WebApi.Application.Common.Specification;
using DN.WebApi.Domain.Catalog.Products;

namespace DN.WebApi.Application.Catalog.Products;

public class ProductsWithBrandsBySearchRequestSpec : ItemsByPaginationFilterSpec<Product>
{
    public ProductsWithBrandsBySearchRequestSpec(SearchProductsRequest request)
        : base(request)
    {
        Query.Include(p => p.Brand);

        if (request.BrandId.HasValue)
        {
            Query.Where(p => p.BrandId.Equals(request.BrandId.Value));
        }

        if (request.MinimumRate.HasValue)
        {
            Query.Where(p => p.Rate >= request.MinimumRate.Value);
        }

        if (request.MaximumRate.HasValue)
        {
            Query.Where(p => p.Rate <= request.MaximumRate.Value);
        }
    }
}