using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IoCApplication.Models.IoCContainer
{
    public class Container
    {
        private Dictionary<Type, ResolvedTypeWithCycleTimeOptions> IoCDictionary = new Dictionary<Type, ResolvedTypeWithCycleTimeOptions>();

        public void Register<T1, T2>()
        {
            Register<T1, T2>(CycleTimeOptions.transient); // default
        }

        public void Register<T1, T2>(CycleTimeOptions CycleTimeOption)
        {
            if (IoCDictionary.ContainsKey(typeof(T1)))
            {
                throw new Exception(string.Format("Type {0} already registered.", typeof(T1).FullName));
            }
            ResolvedTypeWithCycleTimeOptions targetType = new ResolvedTypeWithCycleTimeOptions(typeof(T2), CycleTimeOption);
            IoCDictionary.Add(typeof(T1), targetType);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            // Find the registered type for typeToResolve
            if (!IoCDictionary.ContainsKey(typeToResolve))
                throw new Exception(string.Format("Can't resolve {0}. Type is not registed.", typeToResolve.FullName));

            ResolvedTypeWithCycleTimeOptions resolvedType = IoCDictionary[typeToResolve];

            if (resolvedType.CycleTimeOption == CycleTimeOptions.singleton && resolvedType.InstanceValue != null)
                return resolvedType.InstanceValue; 

            // Try to construct the object
            ConstructorInfo constrInfo = resolvedType.ResolvedType.GetConstructors().First();
            
            List<ParameterInfo> paramsInfo = constrInfo.GetParameters().ToList();
            List<object> resolvedParams = new List<object>();
            foreach (ParameterInfo param in paramsInfo)
            {
                Type t = param.ParameterType;
                object res = Resolve(t);
                resolvedParams.Add(res);
            }

            object retObject = constrInfo.Invoke(resolvedParams.ToArray());
            resolvedType.InstanceValue = retObject;

            return retObject;
        }
    }

}