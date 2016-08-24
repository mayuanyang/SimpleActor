using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using SimpleActor.Core.Autofac;
using SimpleActor.Core.Domain.Actors;

namespace SimpleActor.Service
{
    class SimpleActorService
    {
        private static ActorSystem _system;
        public void Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<SimpleActorCoreModule>();
            var container = builder.Build();
            _system = ActorSystem.Create("simpleActorSystem");
            //_system.EventStream.Subscribe()
            var propsResolver = new AutoFacDependencyResolver(container, _system);
            
            Console.WriteLine("Application Started");
        }

        public void Stop() { }
    }
}
