using System;
using System.Collections.Generic;
using Koos.Domain.Core.Events;

namespace Koos.Infrastructure.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}