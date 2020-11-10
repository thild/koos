using System.Threading.Tasks;

namespace Koos.Domain.Core.Commands
{
    interface IHandler<TCommand, TOutcome> where TCommand : CommandBase
    {
        Task<TOutcome> Handle(TCommand command);
    }
}
