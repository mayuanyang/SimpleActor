using Autofac;
using SimpleActor.Core.EventStores;

namespace SimpleActor.Core.Autofac
{
    public class SimpleActorCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.Name.EndsWith("Actor"));
            builder.RegisterType<InMemoryEventStore>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
