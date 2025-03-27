using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        //Signature for function will return an instance of class that implements IGenericRepository<TEntity, Tkey>
        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity:BaseEntity<Tkey>;
    }
}
