using Koos.Domain.Commands;

namespace Koos.Domain.Validations
{
    public class RemoveGoalCommandValidation : GoalValidation<RemoveGoalCommand>
    {
        public RemoveGoalCommandValidation()
        {
            ValidateId();
        }
    }
}