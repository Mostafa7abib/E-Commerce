using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Shared;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        public ProductWithBrandAndTypeSpecifications(int id): base(product=> product.Id ==id )
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
        public ProductWithBrandAndTypeSpecifications(ProductParametersSpecifications parameters)
            :base(product=>
        (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value)&&
        (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value)&&
        (string.IsNullOrWhiteSpace(parameters.Search)||product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSortOptions.PriceDesc:
                        SetOrderByDesc(product => product.Price);
                        break;
                    case ProductSortOptions.PriceAsc:
                        SetOrderBy(product => product.Price);
                        break;
                    case ProductSortOptions.NameDesc:
                        SetOrderByDesc(product => product.Name);
                        break;
                    default:
                        SetOrderBy(product => product.Name);
                        break;
                }
            }
            ApplyPagination(parameters.PageIndex, parameters.PageSize);
        }
    }
}
