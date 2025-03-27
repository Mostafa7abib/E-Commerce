using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Data;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Dictionary<string,object> _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            //return new GenericRepository<TEntity, Tkey>(_dbContext);
            var typeName = typeof(TEntity).Name; //Key 
            if(_repositories.ContainsKey(typeName))
            {
                return (IGenericRepository<TEntity, Tkey>) _repositories[typeName];
            }
            else
            {
                var repo = new GenericRepository<TEntity, Tkey>(_dbContext);
                _repositories.Add(typeName, repo);
                return repo;
            }
        }

        public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
