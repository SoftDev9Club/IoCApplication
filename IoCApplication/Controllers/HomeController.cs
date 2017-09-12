using IoCApplication.Models.Interface;
using IoCApplication.Models.ResolveService;
using IoCApplication.Models.Implementation;
using IoCApplication.Models.IoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoCApplication.Controllers
{
    public class HomeController : Controller
    {
        private IService1 s1;
        private IService2 s2;
        Container container = new Container();
       
        public HomeController(IService1 s1, IService2 s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }

        public ActionResult Index()
        {
            // Register all the dependencies
            container.Register<IService1, IoCService1>(IoCApplication.Models.CycleTimeOptions.transient);
            container.Register<IService2, IoCService2>(IoCApplication.Models.CycleTimeOptions.singleton);

            ResolveService ResolveService1 = new ResolveService(container);
            ResolveService ResolveService2 = new ResolveService(container);
            ViewBag.serviceTime1 = s1.Service1(); 
            ViewBag.serviceTime2 = s2.Service2(); 
           
            return View();
        }
    }
}