using IoCApplication.Models.Interface;
using IoCApplication.Models.HighLevelModule;
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

       public  HomeController(IService1 s1, IService2 s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }


        public ActionResult Index()
        {
            // Create the container object
            Container container = new Container();
            // Register all the dependencies
            container.Register<IService2, IoCService2>(LifeTimeOptions.singleton);
            container.Register<IService1, IoCService1>(LifeTimeOptions.transient);

            // Prepare the first ResolveService object and do the ResolveService operation
            ResolveService ResolveService1 = new ResolveService(container);
            ResolveService1.DoCopy(); //---------------------------------------------------------------------
            //Console.ReadLine();

            // Prepare the second ResolveService object and do the ResolveService operation
            ResolveService ResolveService2 = new ResolveService(container);
            ResolveService2.DoCopy(); //---------------------------------------------------------------------
            //ResolveService Console.ReadLine();

            //ViewBag.serviceTime1 = _s1.serviceCreatedOn; // -----------------------------------------------
            //ViewBag.serviceTime2 = _s2.serviceCreatedOn; // -----------------------------------------------
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}