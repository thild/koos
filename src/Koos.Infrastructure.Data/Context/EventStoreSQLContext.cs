using Blazor.IndexedDB.Framework;
using Koos.Domain.Core.Events;
using Microsoft.JSInterop;

namespace Koos.Infrastructure.Data.Context
{
    public class EventStoreSQLContext : IndexedDb
    {
        public KoosIndexedSet<StoredEvent> StoredEvent { get; set; }
        public EventStoreSQLContext(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
    }
}