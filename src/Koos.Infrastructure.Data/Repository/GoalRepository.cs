using System.Linq;
using Koos.Domain.Interfaces;
using Koos.Domain.Models;
using Koos.Infrastructure.Data.Context;
using Koos.Infrastructure.Data.Repository;

namespace Koos.Infrastructure.Data.Repository
{
    public class GoalRepository : Repository<Goal>, IGoalRepository
    {
        public GoalRepository(KoosContext context)
            : base(context)
        {

        }

        // public Goal GetByEmail(string email)
        // {
        //     return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        // }
    }
}
