using System;
using Koos.Domain.Core.Events;

namespace Koos.Domain.Events
{
    public class GoalEvent : EventBase
    {
        public GoalEvent(Guid id,
                         string description,
                         string reward,
                         int starsToAchieve,
                         int starsEarned,
                         DateTime startDate,
                         DateTime endDate)
        {
            Id = id;
            Description = description;
            Reward = reward;
            StarsToAchieve = starsToAchieve;
            StarsEarned = starsEarned;
            StartDate = startDate;
            EndDate = endDate;
            AggregateId = Id;
        }
        public Guid Id { get; set; }
        public string Description { get; private set; }
        public string Reward { get; private set; }
        public int StarsToAchieve { get; private set; }
        public int StarsEarned { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}