using IoCApplication.Models.Interface;
using System.Web.Mvc;

namespace IoCApplication.Controllers
{
    public class HomeController : Controller
    {
        private IService1 s1;
        private IService2 s2;
       
        public HomeController(IService1 s1, IService2 s2) 
        {
            this.s1 = s1;
            this.s2 = s2;
        }
        public ActionResult Index()
        {
            ViewBag.serviceTime1 = s1.Service1(); 
            ViewBag.serviceTime2 = s2.Service2(); 
           
            return View();
        }
    }
}