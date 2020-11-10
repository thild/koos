using System;
using Koos.Domain.Commands;
using FluentValidation;

namespace Koos.Domain.Validations
{
    public abstract class GoalValidation<T> : AbstractValidator<T> where T : GoalCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 150).WithMessage("The Description must have between 2 and 150 characters");
        }

        protected void ValidateStartDate()
        {
            RuleFor(c => c.StartDate)
                .NotEmpty()
                .Must(x => x >= DateTime.Today)
                .WithMessage("The start date must be greater or equal today");
        }
        protected void ValidateEndDate()
        {
            RuleFor(c => c.StartDate)
                .NotEmpty()
                .Must((x, y) => y >= x.StartDate)
                .WithMessage("The start date must be greater or equal start date");
        }

        protected void ValidateStarsToAchieve()
        {
            RuleFor(c => c.StarsToAchieve)
                .GreaterThan(0);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}