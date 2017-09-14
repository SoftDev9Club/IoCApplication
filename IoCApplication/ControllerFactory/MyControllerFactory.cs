using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using IoCApplication.Models.Interface;
using IoCApplication.Models.Implementation;
using IoCApplication.Controllers;
using IoCApplication.Models.IoCContainer;

namespace IoCApplication.ControllerFactory
{ 
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {          
            if (controllerName.StartsWith("Home"))
            {
                Container container = new Container();
                container.Register<IService1, IoCService1>(IoCApplication.Models.CycleTimeOptions.transient);
                container.Register<IService2, IoCService2>(IoCApplication.Models.CycleTimeOptions.singleton);
                IService1 service1 = container.Resolve<IService1>();
                IService2 service2 = container.Resolve<IService2>();
                               
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

