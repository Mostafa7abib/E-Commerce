using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Data;

namespace Persistance.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity?> GetByIdAsync(Tkey id)=>
            await _dbContext.Set<TEntity>().FindAsync(id);  
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking)=> asNoTracking ? 
            await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync() : //True
            await _dbContext.Set<TEntity>().ToListAsync(); //False
        public async Task AddAsync(TEntity entity)=>
            await _dbContext.Set<TEntity>().AddAsync(entity);   
        public void Update(TEntity entity)=>
            _dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)=>
            _dbContext.Set<TEntity>().Remove(entity);

        public async Task<TEntity?> GetByIdAsync(Specifications<TEntity> specifications)
        {
            return await ApplySpecifications(specifications).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications)
        {
            return await ApplySpecifications(specifications).ToListAsync();
        }
        private IQueryable<TEntity> ApplySpecifications(Specifications<TEntity> specifications)
        {
            return SpecificationEvaluator.GetQuery<TEntity>(_dbContext.Set<TEntity>(), specifications);
        }

        public async Task<int> CountAsync(Specifications<TEntity> specifications)
        {
            return await ApplySpecifications(specifications).CountAsync();
        }
    }
}
