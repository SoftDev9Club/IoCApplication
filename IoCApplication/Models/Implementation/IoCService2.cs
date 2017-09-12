﻿using IoCApplication.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoCApplication.Models.Implementation
{
    public class IoCService2 : IService2
    {
        private DateTime _createdOn;

        public IoCService2()
        {
            _createdOn = DateTime.Now;
        }

        public string Service2()
        {
            return "service 2 created on: " + _createdOn.ToString();
        }

    }
}