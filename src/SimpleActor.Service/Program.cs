using Topshelf;

namespace SimpleActor.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SimpleActorService>(s =>
                {
                    s.ConstructUsing(name => new SimpleActorService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("SimpleActorService");
                x.SetDisplayName("SimpleActorService");
                x.SetServiceName("SimpleActorService");
            });
        }
    }
}
