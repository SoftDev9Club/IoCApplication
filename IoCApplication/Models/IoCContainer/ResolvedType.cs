using IoCApplication.Models.IoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoCApplication.Models
{
    public enum CycleTimeOptions
    {
        transient,
        singleton
    }
    public class ResolvedTypeWithCycleTimeOptions
    {
        public Type ResolvedType { get; set; }
        public CycleTimeOptions CycleTimeOption { get; set; }
        public object InstanceValue { get; set; }

        public ResolvedTypeWithCycleTimeOptions(Type resolvedType)
        {
            ResolvedType = resolvedType;
            CycleTimeOption = CycleTimeOptions.transient;
            InstanceValue = null; 
        }

        public ResolvedTypeWithCycleTimeOptions(Type resolvedType, CycleTimeOptions CycleTimeOption)
        {
            ResolvedType = resolvedType;
            this.CycleTimeOption = CycleTimeOption;
            InstanceValue = null;
        }
    }
}