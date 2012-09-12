namespace MassTransit.Sandbox.Consumer.Handlers
{
    #region usings

    using System;
    using Messages;

    #endregion

    public class HelloWorldHandler : Consumes<HelloWorldCommand>.All
    {
        #region All Members

        public void Consume(HelloWorldCommand message)
        {
            Console.WriteLine(String.Format("Received {0} with message {1}", message, message.Message));
        }

        #endregion
    }
}
