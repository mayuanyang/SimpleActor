using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using SimpleActor.Messages.Commands;
using SimpleActor.Messages.Events;

namespace SimpleActor.Core.Actors
{
    public class PaymentActor : ReceiveActor, IAggregateActor<PaymentAddedEvent>, IAggregateActor<TransactionAddedEvent>
    {
        private IActorRef txActor;
        
        protected override void PreStart()
        {
            base.PreStart();
            var actorProps = Context.DI().Props<TransactionActor>();

            txActor = Context.ActorOf(actorProps, "myChildTxActor");
        }

        public PaymentActor()
        {
            ReceiveAsync<AddPaymentCommand>(async message => 
            {
                await AddPayment(message.Id, message.Amount, message.Ual);
            });
        }

        private async Task AddPayment(Guid id, decimal amount, string ual)
        {
            // Do some domain logic
            var addTxCmd = new AddTransactionCommand(Guid.NewGuid(), id, amount, ual);
            await txActor.Ask<AddTransactionCommand>(addTxCmd);
            // Raise a event and tell the next actor
            
        }

        public void Apply(PaymentAddedEvent @event)
        {
            
        }

        public void Apply(TransactionAddedEvent @event)
        {
            
        }
    }
}
