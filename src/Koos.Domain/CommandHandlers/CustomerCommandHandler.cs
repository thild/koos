using System;
using System.Threading;
using System.Threading.Tasks;
using Koos.Domain.Commands;
using Koos.Domain.Core.Bus;
using Koos.Domain.Core.Notifications;
using Koos.Domain.Events;
using Koos.Domain.Interfaces;
using Koos.Domain.Models;
using MediatR;

namespace Koos.Domain.CommandHandlers
{
    public class GoalCommandHandler : CommandHandler,
                                      IRequestHandler<RegisterNewGoalCommand, bool>,
                                      IRequestHandler<UpdateGoalCommand, bool>,
                                      IRequestHandler<RemoveGoalCommand, bool>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMediatorHandler Bus;

        public GoalCommandHandler(IGoalRepository GoalRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _goalRepository = GoalRepository;
            Bus = bus;
        }

        public async Task<bool> Handle(RegisterNewGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return false;
            }

            var goal = new Goal(message.Description,
                                message.Reward,
                                message.StarsToAchieve,
                                message.StarsEarned,
                                message.StartDate,
                                message.EndDate);

            if (_goalRepository.GetById(goal.Id) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Goal e-mail has already been taken."));
                return false;
            }

            _goalRepository.Add(goal);

            if (await Commit())
            {
                await Bus.RaiseEvent(new GoalRegisteredEvent(goal.Id,
                                                       goal.Description,
                                                       goal.Reward,
                                                       goal.StarsToAchieve,
                                                       goal.StarsEarned,
                                                       goal.StartDate,
                                                       goal.EndDate));
            }

            return true;
        }

        public async Task<bool> Handle(UpdateGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return false;
            }

            var goal = new Goal(message.Description,
                                message.Reward,
                                message.StarsToAchieve,
                                message.StarsEarned,
                                message.StartDate,
                                message.EndDate);

            var existingGoal = _goalRepository.GetById(goal.Id);

            if (existingGoal != null && existingGoal.Id != goal.Id)
            {
                if (!existingGoal.Equals(goal))
                {
                    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Goal e-mail has already been taken."));
                    return false;
                }
            }

            _goalRepository.Update(goal);

            if (await Commit())
            {
                await Bus.RaiseEvent(new GoalUpdatedEvent(goal.Id,
                                                          goal.Description,
                                                          goal.Reward,
                                                          goal.StarsToAchieve,
                                                          goal.StarsEarned,
                                                          goal.StartDate,
                                                          goal.EndDate));
            }

            return true;
        }

        public async Task<bool> Handle(RemoveGoalCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return false;
            }

            _goalRepository.Remove(message.Id);

            if (await Commit())
            {
                await Bus.RaiseEvent(new GoalRemovedEvent(message.Id));
            }

            return true;
        }

        public void Dispose()
        {
            _goalRepository.Dispose();
        }
    }
}