using System;
using Akka;
using Akka.Actor;
using SimpleActor.Core.Messages;
using SimpleActor.Core.Messages.Commands;

namespace SimpleActor.Core.Actors
{
    public class PaymentActor : AggregateRootActor
    {
        private IActorRef _txActor;
        public PaymentActor(AggregateRootCreationParameters parameters) : base(parameters)
        {
            
        }
        protected override bool Handle(IDomainCommand command)
        {
            return command.Match()
                .With<AddPaymentCommand>(x => x.)
        }


        private void AddPayment(AddPaymentCommand cmd)
        {
            
        }

        protected override bool Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }

       
    }
}
