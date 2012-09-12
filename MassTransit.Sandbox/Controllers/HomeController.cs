namespace MassTransit.Sandbox.Controllers
{
    #region usings

    using System;
    using System.Web.Mvc;
    using Messages;
    using Common.Infrastructure;

    #endregion

    public class HomeController : Controller
    {
        #region fields

        private readonly IServiceBus _bus;

        #endregion

        #region ctor

        public HomeController(IServiceBus bus)
        {
            if (bus == null) throw new ArgumentNullException("bus");

            _bus = bus;
        }

        #endregion

        #region actions

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            _bus.Send(new HelloWorldCommand { Message = "Hello MassTransit" });

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        #endregion
    }
}
