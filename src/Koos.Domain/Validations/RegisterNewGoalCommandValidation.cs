using Koos.Domain.Commands;

namespace Koos.Domain.Validations
{
    public class RegisterNewGoalCommandValidation : GoalValidation<RegisterNewGoalCommand>
    {
        public RegisterNewGoalCommandValidation()
        {
            ValidateDescription();
            ValidateEndDate();
            ValidateId();
            ValidateStarsToAchieve();
            ValidateStartDate();
        }
    }
}