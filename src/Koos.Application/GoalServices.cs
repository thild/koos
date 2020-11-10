using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.IndexedDB.Framework;
using Blazored.LocalStorage;
using Koos.Domain.Models;

namespace Koos.Application.Services
{
    public class GoalServices : ServiceBase<Goal>
    {
        public GoalServices(ILocalStorageService localStorageService, IIndexedDbFactory dbFactory) : base(localStorageService, dbFactory)
        {

        }

        // public override async Task SaveAsync(Goal item, bool update = false)
        // {
        //     using var db = await DbFactory.Create<KoosDb>();
        //     if (update)
        //     {
        //         System.Console.WriteLine("update");
        //         var oldItem = db.Set<Goal>().Where(x => x.Id == item.Id);
                
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("!update");
        //         db.Set<Goal>().Add(item);
        //     }
        //     await db.SaveChanges();
        //     // _entities.TryGetValue(item.Id, out var entity);
        //     // if (entity is null)
        //     // {
        //     //     _entities.Add(item.Id, item);
        //     //     await LocalStorageService.SetItemAsync(nameof(T), _entities.Keys);
        //     // }
        //     // await LocalStorageService.SetItemAsync(item.Id.ToString(), item);
        // }
    }
}
