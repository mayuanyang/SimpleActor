using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;

namespace SimpleActor.Core.Domain.Actors
{
    public static class AggregateFactory
    {
        public static IActorRef AccountAggregate(this ActorSystem system, Guid id, int snapshotThreshold = 250)
        {
            var projectionsProps = new ConsistentHashingPool(5).Props(Props.Create<ReadModelProjectionActor>());

            var projections = system.ActorOf(projectionsProps, SystemData.ProjectionsActor.Name);

            var creationParams = new AggregateRootCreationParameters(id, projections, snapshotThreshold);

            return system.ActorOf(Props.Create<Account>(creationParams), "aggregates(account)");
        }
    }
}
