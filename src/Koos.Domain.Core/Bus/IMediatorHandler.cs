using System.Threading.Tasks;
using Koos.Domain.Core.Commands;
using Koos.Domain.Core.Events;


namespace Koos.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : CommandBase;
        Task RaiseEvent<T>(T @event) where T : EventBase;
    }
}
