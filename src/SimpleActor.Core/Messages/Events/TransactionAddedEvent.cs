using System;

namespace SimpleActor.Core.Messages.Events
{
    public class TransactionAddedEvent : IDomainEvent, IDomainCommand
    {
        public Guid AggregateId { get; }
        public Guid EntityId { get; set; }
        public decimal Amount { get; }
        public string Ual { get; }

        public TransactionAddedEvent(Guid id, Guid entityId, decimal amount, string ual)
        {
            AggregateId = id;
            EntityId = entityId;
            Amount = amount;
            Ual = ual;
        }
    }
}
