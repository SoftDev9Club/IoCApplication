using IoCApplication.Models.Interface;
using System;

namespace IoCApplication.Models.Implementation
{
    public class IoCService1 : IService1
    {
        private DateTime _createdOn;

        public IoCService1() 
        {
            _createdOn = DateTime.Now;
        }

        public string Service1()
        {
            return "service1 created on:"+ _createdOn.ToString();
        }
    }
}