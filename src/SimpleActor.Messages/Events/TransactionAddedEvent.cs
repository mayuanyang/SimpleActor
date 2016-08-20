using System;

namespace SimpleActor.Messages.Events
{
    public class TransactionAddedEvent
    {
        public Guid Id { get; }
        public Guid PaymentId { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public TransactionAddedEvent(Guid id, Guid paymentId, decimal amount, string ual)
        {
            Id = id;
            PaymentId = paymentId;
            Amount = amount;
            Ual = ual;
        }
    }
}
