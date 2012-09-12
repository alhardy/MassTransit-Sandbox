namespace MassTransit.Sandbox.Common.Infrastructure
{
    #region usings

    using System;

    #endregion

    public static class ServiceBusExtensions
    {
        public static void Send<T>(this IServiceBus bus, T command) where T : class
        {
            var uri = new Uri("msmq://localhost/masstransit.sandbox.consumer"); //Hmmm, it would be nice to be able to configure a messages's endpoint on startup...
            bus.GetEndpoint(uri).Send(command);
        }
    }
}
