using System;
using Akka;
using Akka.Actor;
using Akka.Persistence;
using SimpleActor.Core.Messages;

namespace SimpleActor.Core.Actors
{
    public class AggregateRootCreationParameters
    {
        public AggregateRootCreationParameters(Guid id, IActorRef readModelProjectionActor, int snapshotThreshold = 250)
        {
            Id = id;
            ReadModelProjectionActor = readModelProjectionActor;
            SnapshotThreshold = snapshotThreshold;
        }

        public Guid Id { get; private set; }
        public IActorRef ReadModelProjectionActor { get; private set; }
        public int SnapshotThreshold { get; private set; }
    }

    public abstract class AggregateRootActor : PersistentActor
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
        protected override bool ReceiveRecover(object message)
        {
            return message.Match()
               .With<IDomainEvent>(x => Apply(x))
               .WasHandled;
        }

        protected override bool ReceiveCommand(object message)
        {
            return message.Match()
                .With<IDomainCommand>(cmd =>
                {
                    Handle(cmd);
                    
                }).WasHandled;
            
        }

        public override string PersistenceId => _id.ToString();

        protected abstract bool Handle(IDomainCommand command);
        protected abstract bool Apply(IDomainEvent @event);
    }
}
