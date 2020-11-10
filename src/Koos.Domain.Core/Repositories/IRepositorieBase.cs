using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koos.Domain.Core.Repositories
{
    public interface IRepositoryBase<TEntity> 
    {
        Task<TEntity> GetByIdAsync(Guid? id);
        Task AddAsync(TEntity dto);
        Task UpdateAsync(Guid? id, TEntity dto);
        Task DeleteAsync(Guid? id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(IEnumerable<string> fields);
    }
}

