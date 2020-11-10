using System;
using Koos.Domain.Validations;

namespace Koos.Domain.Commands
{
    public class UpdateGoalCommand : GoalCommand
    {
        public UpdateGoalCommand(Guid id,
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
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}