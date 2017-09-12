using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using IoCApplication.Models.Interface;
using IoCApplication.Models.Implementation;
using IoCApplication.Controllers;

namespace IoCApplication.ControllerFactory
{

   
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
           
            if (controllerName.StartsWith("Home"))
            { 
            IService1 service1 = new IoCService1();
            IService2 service2 = new IoCService2();
            IController controller = new HomeController(service1, service2);
            return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}

