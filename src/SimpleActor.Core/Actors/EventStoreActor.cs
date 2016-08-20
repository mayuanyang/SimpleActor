using Akka.Actor;
using SimpleActor.Core.EventStores;

namespace SimpleActor.Core.Actors
{
    public class EventStoreActor : UntypedActor
    {
        private readonly IEventStore _eventStore;

        public EventStoreActor(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        protected override void OnReceive(object message)
        {

            _eventStore.PersistEvent(message);
        }
    }
}
