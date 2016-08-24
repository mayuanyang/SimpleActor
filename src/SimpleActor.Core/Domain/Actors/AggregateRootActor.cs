using System;
using Akka;
using Akka.Actor;
using Akka.Persistence;
using SimpleActor.Core.Messages;

namespace SimpleActor.Core.Domain.Actors
{
    public abstract class AggregateRootActor : ReceivePersistentActor
    {
        private readonly Guid _id;
        private readonly IActorRef _projections;
        private readonly int _snapshotThreshold;
        

        public AggregateRootActor(AggregateRootCreationParameters parameters)
        {
            _id = parameters.Id;
            _projections = parameters.ReadModelProjectionActor;
            _snapshotThreshold = parameters.SnapshotThreshold;
            
        }
        protected void Setup()
        {
            // When the aggregate is being loaded
            Recover<IDomainEvent>(Apply);

            // When someone send me a command
            Command<IDomainCommand>(Handle);

            // When my child actor finished the command i sent and acknowledge back with an event
            Command<IDomainEvent>(Apply);
        }

        

        public override string PersistenceId => _id.ToString();

        protected abstract bool Handle(IDomainCommand command);
        protected abstract bool Apply(IDomainEvent @event);
    }
}
