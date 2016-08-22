namespace SimpleActor.Core.Domain.Actors
{
    public interface IEventRaisingActor<in T>
    {
        void NotifyAggregateRoot(T @event);
    }
}
