namespace MassTransit.Sandbox.Web.Infrastructure
{
    #region usings

    using Autofac;

    #endregion

    public class MassTransitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => ServiceBusFactory.New(sbc =>
            {
                sbc.UseMsmq();
                sbc.VerifyMsmqConfiguration();
                sbc.ReceiveFrom("msmq://localhost/masstransit.sandbox.web");
            })).As<IServiceBus>().SingleInstance();
        }
    }
}
