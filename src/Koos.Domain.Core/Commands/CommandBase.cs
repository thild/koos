using System;
using System.ComponentModel.DataAnnotations;
using Koos.Domain.Core.Events;

namespace Koos.Domain.Core.Commands
{
    public abstract class CommandBase : Message
    {
        public DateTime Timestamp { get; private set; }
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        protected CommandBase()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
