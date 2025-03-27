namespace Persistance.Data.DataSeeding
{
    public class DbIntializer : IDbIntializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbIntializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task IntializeAsync()
        {
            try
            {
                if(_dbContext.Database.GetPendingMigrations().Any())
                {
                    await _dbContext.Database.MigrateAsync();
                    if (!_dbContext.ProductTypes.Any())
                    {
                        var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                        if (types != null&&types.Any())
                        {
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (!_dbContext.ProductBrands.Any())
                    {
                        var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                        if (brands != null && brands.Any())
                        {
                            await _dbContext.AddRangeAsync(brands);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (!_dbContext.Products.Any())
                    {
                        var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                        if (products != null && products.Any())
                        {
                            await _dbContext.AddRangeAsync(products);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
