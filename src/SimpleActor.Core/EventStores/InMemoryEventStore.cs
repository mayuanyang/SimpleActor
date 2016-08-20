using System.Collections;
using System.Threading.Tasks;

namespace SimpleActor.Core.EventStores
{
    public class InMemoryEventStore : IEventStore
    {
        private IList _events = new ArrayList();
      
        public Task PersistEvent(object @event)
        {
            _events.Add(@event);
            return Task.FromResult(0);
        }
    }
}