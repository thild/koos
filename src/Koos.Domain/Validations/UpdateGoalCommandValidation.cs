using Koos.Domain.Commands;

namespace Koos.Domain.Validations
{
    public class UpdateGoalCommandValidation : GoalValidation<UpdateGoalCommand>
    {
        public UpdateGoalCommandValidation()
        {
            ValidateDescription();
            ValidateEndDate();
            ValidateId();
            ValidateStarsToAchieve();
            ValidateStartDate();
        }
    }
}