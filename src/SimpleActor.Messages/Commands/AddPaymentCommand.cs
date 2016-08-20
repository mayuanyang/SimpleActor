using System;

namespace SimpleActor.Messages.Commands
{
    public class AddPaymentCommand
    {
        public Guid Id { get; }
        public decimal Amount { get; }
        public string Ual { get; }

        public AddPaymentCommand(Guid id, decimal amount, string ual)
        {
            Id = id;
            Amount = amount;
            Ual = ual;
        }
    }
}
