using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IoCApplication.Models.IoCContainer;
using IoCApplication.Models.Interface;


namespace IoCApplication.Models.ResolveService
{
    public class ResolveService
    {
        private Container _container;
        private IService1 _service1;
        private IService2 _service2;
        

        public ResolveService(Container container)
        {
            _container = container;
            _service1 = _container.Resolve<IService1>();
            _service2 = _container.Resolve<IService2>();
          
        }

        public void DoCopy()
        {
            //string stData = _service2.Read();
           // Console.WriteLine(string.Format("Reader created on : {0}", _service2.GetCreatedOn().ToString()));
          //  Console.WriteLine(string.Format("Writer created on : {0}", _service1.GetCreatedOn().ToString()));
           // _service1.Write(stData);
         //   Console.WriteLine("\n\n");
        }
    }
}