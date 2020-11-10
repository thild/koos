using System;
using Koos.Domain.Validations;

namespace Koos.Domain.Commands
{
    public class RegisterNewGoalCommand : GoalCommand
    {
        public RegisterNewGoalCommand(string description,
                                      string reward,
                                      int starsToAchieve,
                                      int starsEarned,
                                      DateTime startDate,
                                      DateTime endDate)
        {
            Description = description;
            Reward = reward;
            StarsToAchieve = starsToAchieve;
            StarsEarned = starsEarned;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}