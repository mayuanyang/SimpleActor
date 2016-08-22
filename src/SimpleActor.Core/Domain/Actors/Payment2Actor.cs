using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Persistence;
using Akka.Util.Internal;

namespace SimpleActor.Core.Domain.Actors
{
    public class Payment2Actor : ReceivePersistentActor
    {
        public override string PersistenceId { get; }

        private TransactionActor _txActor;
        public Payment2Actor()
        {
            
            Command<string>(x =>
            {
                Console.WriteLine(x);
            });
        }
        
    }
}
