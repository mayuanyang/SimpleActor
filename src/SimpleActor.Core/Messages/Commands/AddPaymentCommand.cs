using System;

namespace SimpleActor.Core.Messages.Commands
{
    public class AddPaymentCommand : IDomainCommand
    {
        public decimal Amount { get; }
        public string Ual { get; }

        public AddPaymentCommand(Guid aggregateId, decimal amount, string ual)
        {
            AggregateId = aggregateId;
            Amount = amount;
            Ual = ual;
        }

        public Guid AggregateId { get; }
    }
}
