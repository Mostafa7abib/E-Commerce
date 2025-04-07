using Shared;

namespace Services.Absraction
{
    public interface IProductService
    {
        // 1) Get All Products
        // 2) Get All Brands
        // 3) Get All Types
        // 4) Get Product By Id
        //DTOs ==> Data Transfer Object 
        // 1) Get All Products
        public Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(string? sort, int? brandId, int? typeId);
        // 2) Get Product By Id
        public Task<ProductResultDto> GetProductByIdAsync(int id);
        // 3) Get All Brands
        public Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();
        // 4) Get All Types
        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();
    }
}
