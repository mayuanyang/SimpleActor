using System;

namespace SimpleActor.Core.Messages
{
    public interface IDomainEvent
    {
        Guid AggregateId { get; }
        Guid EntityId { get; }
    }
}
