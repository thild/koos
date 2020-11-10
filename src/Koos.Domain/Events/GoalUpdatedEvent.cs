﻿using System;
using Koos.Domain.Core.Events;

namespace Koos.Domain.Events
{
    public class GoalUpdatedEvent : GoalEvent
    {
        public GoalUpdatedEvent(Guid id,
                                   string description,
                                   string reward,
                                   int starsToAchieve,
                                   int starsEarned,
                                   DateTime startDate,
                                   DateTime endDate) : base(id,
                                                            description,
                                                            reward,
                                                            starsToAchieve,
                                                            starsEarned,
                                                            startDate,
                                                            endDate)
        { }
    }
}