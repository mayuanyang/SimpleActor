using System;

namespace SimpleActor.Messages.Commands
{
    public class AddTransactionCommand
    {
        public Guid Id { get; }
        public Guid PaymentId { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public AddTransactionCommand(Guid id, Guid paymentId, decimal amount, string ual)
        {
            Id = id;
            PaymentId = paymentId;
            Amount = amount;
            Ual = ual;
        }
    }
}
