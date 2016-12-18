using System;
using System.Configuration;

namespace Generics.Common.Factory
{
    public static class Container
    {
        public static T Resolve<T>() where T : class
        {
            string configString = 
                ConfigurationManager.AppSettings[typeof(T).ToString()];
            Type resolvedType = Type.GetType(configString);
            object instance = Activator.CreateInstance(resolvedType);
            T result = instance as T;
            return result;
        }
    }
}
