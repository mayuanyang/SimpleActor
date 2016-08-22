using System;

namespace SimpleActor.Core.Domain.Entities
{
    public class Transaction
    {
        public Guid AggregateId { get; private set; }
        public Guid EntityId { get; private set; }
        public decimal Amount { get; private set; }
        public string Ual { get; private set; }

        public Transaction(Guid aggregateId, Guid entityId, decimal amount, string ual)
        {
            AggregateId = aggregateId;
            EntityId = entityId;
            Amount = amount;
            Ual = ual;
        }
    }
}
