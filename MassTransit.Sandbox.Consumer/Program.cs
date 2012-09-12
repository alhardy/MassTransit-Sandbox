namespace MassTransit.Sandbox.Consumer
{
    #region usings

    using Autofac;
    using Infrastructure;
    using Topshelf;

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MassTransitModule>();

            var container = builder.Build();

            HostFactory.Run(c =>
            {
                c.SetServiceName("MassTransit.Consumer");
                c.SetDisplayName("MassTransit Consumer");
                c.SetDescription("MassTransit Service Consumer Test");

                c.DependsOnMsmq();
                c.RunAsLocalService();


                c.Service<ConsumerService>(s =>
                {
                    s.ConstructUsing(x => new ConsumerService(container.Resolve<IServiceBus>()));
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o =>
                    {
                        o.Stop();
                        container.Dispose();
                    });
                });
            });
        }
    }
}
