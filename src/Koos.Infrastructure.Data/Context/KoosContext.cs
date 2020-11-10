using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Blazor.IndexedDB.Framework;
using Koos.Domain.Models;
using Microsoft.JSInterop;

namespace Koos.Infrastructure.Data.Context
{
    public class KoosIndexedSet<TEntity> : IndexedSet<TEntity>, IQueryable, IQueryable<TEntity> where TEntity : class, new()
    {
        private readonly IndexedDb context;

        public KoosIndexedSet(IndexedDb context, IEnumerable<TEntity> records, PropertyInfo primaryKey) : base(records, primaryKey)
        {
            this.context = context;
        }
        public virtual TEntity Find(params object[] keyValues)
        {
            TEntity item = default;
            foreach (var value in keyValues)
            {
                item = this.Where(x => x == value).Single();
            }
            return item;
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            context.SaveChanges();
            return new EntityEntry<TEntity> { State = EntityState.Modified };
        }

        public Type ElementType => typeof(TEntity);

        public Expression Expression => this.AsQueryable().Expression;

        public IQueryProvider Provider => this.AsQueryable().Provider;

    }

    public class EntityEntry<TEntity> where TEntity : class
    {
        public EntityState State { get; set; }
    }

    public class KoosContext : IndexedDb
    {
        private IDictionary<Type, object> _sets;
        public KoosContext(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }

        public virtual KoosIndexedSet<TEntity> Set<TEntity>() where TEntity : class, new()
        {

            if (_sets == null)
            {
                _sets = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);

            if (!_sets.TryGetValue(type, out var set))
            {
                var tables = this.GetType().GetProperties()
                    .Where(x => x.PropertyType.IsGenericType &&
                                x.PropertyType.GetGenericTypeDefinition() == typeof(IndexedSet<>) &&
                                x.PropertyType.GetGenericArguments().Contains(typeof(TEntity))).FirstOrDefault();
                set = tables.GetValue(this);
                _sets[type] = set;
            }

            return (KoosIndexedSet<TEntity>)set;
        }
        public KoosIndexedSet<Goal> Goals { get; set; }
    }
}
