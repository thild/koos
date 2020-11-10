namespace Koos.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : EventBase;
    }
}