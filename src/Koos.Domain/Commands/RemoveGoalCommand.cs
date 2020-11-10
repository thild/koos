using System;
using Koos.Domain.Validations;

namespace Koos.Domain.Commands
{
    public class RemoveGoalCommand : GoalCommand
    {
        public RemoveGoalCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveGoalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}