using System;

namespace SimpleActor.Core.Messages.Commands
{
    public class AddTransactionCommand : IDomainCommand
    {
        public Guid AggregateId { get; }
        public Guid PaymentId { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public AddTransactionCommand(Guid id, Guid paymentId, decimal amount, string ual)
        {
            AggregateId = id;
            PaymentId = paymentId;
            Amount = amount;
            Ual = ual;
        }
    }
}
