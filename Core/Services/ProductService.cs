using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Absraction;
using Services.Specifications;
using Shared;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var products =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductWithBrandAndTypeSpecifications(id));
            //var productsResult = _mapper.Map<ProductResultDto>(products);
            //return productsResult;
            return products is null? throw new ProductNotFoundException(id) : _mapper.Map<ProductResultDto>(products);
        }
        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductParametersSpecifications parameters)
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(parameters));
            var totalCount = await _unitOfWork.GetRepository<Product, int>().CountAsync(new ProductsCountSpecifications(parameters));
            var productsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            //return productsResult;
            var result = new PaginatedResult<ProductResultDto>(
                parameters.PageSize,
                parameters.PageIndex,
                totalCount,
                productsResult
                );
            return result;
        }
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            // 1- Retrieve Data From Database [Inject IUnitOfWork]
            // 2- Map From ProductBrand To BrandResultDto [Install Package Of Auto Mapper]
            // 3- Return
            var brands = await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var brandsresult = _mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return brandsresult;
        }
        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType,int>().GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeResultDto>>(types);
            return typesResult;
        }
    }
}
