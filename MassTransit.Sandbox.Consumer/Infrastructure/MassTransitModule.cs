namespace MassTransit.Sandbox.Consumer.Infrastructure
{
    #region usings

    using Autofac;
    using Magnum.Extensions;
    using MassTransit;

    #endregion

    public class MassTransitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).Where(t => t.Implements<IConsumer>()).AsSelf();

            builder.Register(c => ServiceBusFactory.New(sbc =>
            {
                sbc.UseMsmq();
                sbc.VerifyMsmqConfiguration();
                sbc.ReceiveFrom("msmq://localhost/masstransit.sandbox.consumer");
                sbc.Subscribe(x => x.LoadFrom(c.Resolve<ILifetimeScope>()));
            })).As<IServiceBus>().SingleInstance();
        }
    }
}
