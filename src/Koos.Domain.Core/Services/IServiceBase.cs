using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heaolu.Domain.Core.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid? id);
        Task AddAsync(TEntity dto);
        Task UpdateAsync(Guid? id, TEntity dto);
        Task DeleteAsync(Guid? id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(IEnumerable<string> fields);
    }
}