using System;
using Akka.Actor;

namespace SimpleActor.Core.Domain.Actors
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
}