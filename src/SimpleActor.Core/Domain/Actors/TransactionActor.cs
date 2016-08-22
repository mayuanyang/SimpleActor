using System.Threading.Tasks;
using Akka.Actor;
using SimpleActor.Core.Messages.Commands;
using SimpleActor.Core.Messages.Events;

namespace SimpleActor.Core.Domain.Actors
{
    public class TransactionActor : ReceiveActor, IEventRaisingActor<TransactionAddedEvent>
    {
        public TransactionActor()
        {
            ReceiveAsync<AddTransactionCommand>(async msg => await AddTransaction(msg));
        }

        private async Task AddTransaction(AddTransactionCommand msg)
        {
            NotifyAggregateRoot(new TransactionAddedEvent(msg.AggregateId, msg.PaymentId, msg.Amount, msg.Ual));
            await Task.FromResult(0);
        }

        public void NotifyAggregateRoot(TransactionAddedEvent @event)
        {
            Sender.Tell(@event, Self);
        }
    }
}
