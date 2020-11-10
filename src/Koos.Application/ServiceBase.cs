using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.IndexedDB.Framework;
using Blazored.LocalStorage;
using Koos.Infrastructure.Data;
using Koos.Domain.Core.Models;
using Koos.Domain.Models;
using Koos.Infrastructure.Data.Context;

namespace Koos.Application.Services
{
    public abstract partial class ServiceBase<T> where T : class, IEntity, new()
    {
        Dictionary<Guid, T> _entities = new Dictionary<Guid, T>();
        public ServiceBase(ILocalStorageService localStorageService, IIndexedDbFactory dbFactory)
        {
            LocalStorageService = localStorageService;
            DbFactory = dbFactory;
        }

        protected ILocalStorageService LocalStorageService { get; }
        public IIndexedDbFactory DbFactory { get; }

        public virtual async Task SaveAsync(T item, bool update = false)
        {
            using var db = await DbFactory.Create<KoosContext>();
            if (update)
            {
                System.Console.WriteLine("update");
                var oldItem = db.Set<T>().Where(x => x.Id == item.Id).FirstOrDefault();
                oldItem.Fill(item);
            }
            else
            {
                System.Console.WriteLine("!update");
                db.Set<T>().Add(item);
            }
            await db.SaveChanges();
            // _entities.TryGetValue(item.Id, out var entity);
            // if (entity is null)
            // {
            //     _entities.Add(item.Id, item);
            //     await LocalStorageService.SetItemAsync(nameof(T), _entities.Keys);
            // }
            // await LocalStorageService.SetItemAsync(item.Id.ToString(), item);
        }

        public virtual async Task DeleteAsync(T item)
        {
            using var db = await DbFactory.Create<KoosContext>();
            db.Set<T>().Remove(item);
            await db.SaveChanges();
            // await LocalStorageService.RemoveItemAsync(id.ToString());
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            using var db = await DbFactory.Create<KoosContext>();
            return db.Set<T>().Where(x => x.Id == id).FirstOrDefault();
        }
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            using var db = await DbFactory.Create<KoosContext>();
            return db.Set<T>();
        }

    }
}