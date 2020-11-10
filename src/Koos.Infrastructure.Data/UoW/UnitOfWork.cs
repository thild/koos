using System.Threading.Tasks;
using Koos.Domain.Interfaces;
using Koos.Infrastructure.Data.Context;

namespace Koos.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KoosContext _context;

        public UnitOfWork(KoosContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            try
            {
                await _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
