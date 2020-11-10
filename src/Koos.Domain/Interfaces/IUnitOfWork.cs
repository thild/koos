using System;
using System.Threading.Tasks;

namespace Koos.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
