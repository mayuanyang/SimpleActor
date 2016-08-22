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

namespace SimpleActor.Service
{
    class SimpleActorService
    {
        public void Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<SimpleActorCoreModule>();
            var container = builder.Build();
            var system = ActorSystem.Create("simpleActorSystem");
            var propsResolver = new AutoFacDependencyResolver(container, system);
            Console.WriteLine("Application Started");
        }

        public void Stop() { }
    }
}
