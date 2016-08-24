using System;
using System.Threading.Tasks;
using Akka.Actor;
using SimpleActor.Core.Messages.Commands;
using SimpleActor.Core.Messages.Events;

namespace SimpleActor.Core.Domain.Actors
{
    public class TransactionActor : ReceiveActor
    {
        public TransactionActor()
        {
            ReceiveAsync<AddTransactionCommand>(async msg =>
            {
                var evt = await Task.Run(() => new TransactionAddedEvent(msg.AggregateId, msg.PaymentId, msg.Amount, msg.Ual));
                Sender.Tell(evt, Self);
            });
        }
       
    }
}
