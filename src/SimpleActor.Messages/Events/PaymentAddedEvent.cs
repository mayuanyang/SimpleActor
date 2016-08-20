using System;

namespace SimpleActor.Messages.Events
{
    public class PaymentAddedEvent
    {
        public Guid Id { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public PaymentAddedEvent(Guid id, decimal amount, string ual)
        {
            Id = id;
            Amount = amount;
            Ual = ual;
        }
    }
}
