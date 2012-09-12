namespace MassTransit.Sandbox.Consumer.Infrastructure
{
    #region usings

    using System;

    #endregion

    public class ConsumerService
    {
        #region fields

        private readonly IServiceBus _bus;

        #endregion

        #region ctor

        public ConsumerService(IServiceBus bus)
        {
            if (bus == null) throw new ArgumentNullException("bus");

            _bus = bus;
        }

        #endregion

        #region public methods

        public void Start() { Console.WriteLine(String.Format("Starting {0}", this)); }

        public void Stop() { Console.WriteLine(String.Format("Stopping {0}", this)); _bus.Dispose(); }

        #endregion        
    }
}
