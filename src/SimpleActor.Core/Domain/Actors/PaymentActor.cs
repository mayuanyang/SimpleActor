using System.Collections;
using System.Collections.Generic;
using Akka;
using Akka.Actor;
using SimpleActor.Core.Domain.Entities;
using SimpleActor.Core.Messages;
using SimpleActor.Core.Messages.Commands;
using SimpleActor.Core.Messages.Events;

namespace SimpleActor.Core.Domain.Actors
{
    public class PaymentActor : AggregateRootActor, IEventRaisingActor<PaymentAddedEvent>
    {
        private IActorRef _txActor;
        private decimal _amount;
        private string _ual;
        private IList<Transaction> _transactions;

       
        public PaymentActor(AggregateRootCreationParameters parameters) : base(parameters)
        {
            _transactions = new List<Transaction>();
        }
        protected override bool Handle(IDomainCommand command)
        {
            return command.Match()
                .With<AddPaymentCommand>(AddPayment).WasHandled;
        }


        protected override bool Apply(IDomainEvent @event)
        {
            return @event.Match()
                .With<PaymentAddedEvent>(x =>
                {
                    _amount = x.Amount;
                    _ual = x.Ual;
                })
                .With<TransactionAddedEvent>(x =>
                {
                    _transactions.Add(new Transaction(x.AggregateId, x.EntityId, x.Amount, x.Ual));

                })
                .WasHandled;
        }
        

        public void NotifyAggregateRoot(PaymentAddedEvent @event)
        {
            Apply(@event);
        }

        private void AddPayment(AddPaymentCommand cmd)
        {
            NotifyAggregateRoot(new PaymentAddedEvent(cmd.AggregateId, cmd.AggregateId, cmd.Amount, cmd.Ual));
        }
    }
}
