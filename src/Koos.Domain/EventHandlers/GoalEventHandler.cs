using System.Threading;
using System.Threading.Tasks;
using Koos.Domain.Events;
using MediatR;

namespace Koos.Domain.EventHandlers
{
    public class GoalEventHandler :
        INotificationHandler<GoalRegisteredEvent>,
        INotificationHandler<GoalUpdatedEvent>,
        INotificationHandler<GoalRemovedEvent>
    {
        public Task Handle(GoalUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(GoalRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(GoalRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}