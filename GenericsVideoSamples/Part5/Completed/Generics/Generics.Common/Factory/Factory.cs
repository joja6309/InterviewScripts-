using System;
using System.Configuration;

namespace Generics.Common.Factory
{
    public static class Factory
    {
        public static T Get<T>() //where T : class
        {
            string typeName =
                ConfigurationManager.AppSettings[typeof(T).ToString()];
            Type resolvedType = Type.GetType(typeName);
            object instance = Activator.CreateInstance(resolvedType);
            T result = default(T);
            if (instance is T)
                result = (T)instance;
            return result;
        }
    }
}
