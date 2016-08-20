using System.Threading.Tasks;

namespace SimpleActor.Core.EventStores
{
    public interface IEventStore
    {
        Task PersistEvent(object @event);
    }
}
