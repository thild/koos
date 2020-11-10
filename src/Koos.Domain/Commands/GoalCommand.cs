using System;
using Koos.Domain.Core.Commands;

namespace Koos.Domain.Commands
{
    public abstract class GoalCommand : CommandBase
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public string Reward { get; protected set; }
        public int StarsToAchieve { get; protected set; }
        public int StarsEarned { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
    }
}