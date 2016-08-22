using System;

namespace SimpleActor.Core.Messages.Events
{
    public class PaymentAddedEvent : IDomainEvent
    {
        public Guid AggregateId { get; }
        public Guid EntityId { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public PaymentAddedEvent(Guid id, Guid entityId, decimal amount, string ual)
        {
            AggregateId = id;
            EntityId = entityId;
            Amount = amount;
            Ual = ual;
        }
    }
}
