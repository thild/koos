using System;
using MediatR;

namespace Koos.Domain.Core.Events
{
    public abstract class EventBase : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected EventBase()
        {
            Timestamp = DateTime.Now;
        }
    }
}