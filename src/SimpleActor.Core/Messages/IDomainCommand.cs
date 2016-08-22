using System;

namespace SimpleActor.Core.Messages
{
    public interface IDomainCommand
    {
        Guid AggregateId { get; }
    }
}
