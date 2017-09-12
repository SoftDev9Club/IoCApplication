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

        
    }
}