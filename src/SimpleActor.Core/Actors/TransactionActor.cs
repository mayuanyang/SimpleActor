using System.Threading.Tasks;
using Akka.Actor;
using SimpleActor.Messages.Commands;
using SimpleActor.Messages.Events;

namespace SimpleActor.Core.Actors
{
    public class TransactionActor : ReceiveActor, IEventRaisingActor<TransactionAddedEvent>
    {
        public TransactionActor()
        {
            ReceiveAsync<AddTransactionCommand>(async msg => await AddTransaction(msg));
        }

        private async Task AddTransaction(AddTransactionCommand msg)
        {
            ApplyChange(new TransactionAddedEvent(msg.Id, msg.PaymentId, msg.Amount, msg.Ual));
            await Task.FromResult(0);
        }

        public void ApplyChange(TransactionAddedEvent @event)
        {
            
        }
    }
}
