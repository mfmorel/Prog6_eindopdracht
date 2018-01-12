using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Domain;

namespace Prog6.Controllers
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Prog6Entities context = new Prog6Entities();
            var controller = new HomeController(context);
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}