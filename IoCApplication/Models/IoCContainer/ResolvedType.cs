using IoCApplication.Models.IoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoCApplication.Models
{
    public class ResolvedTypeWithLifeTimeOptions
    {
        public Type ResolvedType { get; set; }
        public LifeTimeOptions LifeTimeOption { get; set; }
        public object InstanceValue { get; set; }

        public ResolvedTypeWithLifeTimeOptions(Type resolvedType)
        {
            ResolvedType = resolvedType;
            LifeTimeOption = LifeTimeOptions.transient;
            InstanceValue = null;
        }

        public ResolvedTypeWithLifeTimeOptions(Type resolvedType, LifeTimeOptions lifeTimeOption)
        {
            ResolvedType = resolvedType;
            LifeTimeOption = lifeTimeOption;
            InstanceValue = null;
        }
    }
}