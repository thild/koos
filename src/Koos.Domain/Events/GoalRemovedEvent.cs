using System;
using Koos.Domain.Core.Events;

namespace Koos.Domain.Events
{
    public class GoalRemovedEvent : EventBase
    {
        public GoalRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}