using System;
using System.Configuration;
using Generics.Common.Interface;

namespace Generics.Common.Factory
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetPersonRepository()
        {
            string typeName =
                ConfigurationManager.AppSettings["IPersonRepository"];
            Type resolvedType = Type.GetType(typeName);
            object instance = Activator.CreateInstance(resolvedType);
            return instance as IPersonRepository;
        }

        public static IProductRepository GetProductRepository()
        {
            string typeName =
                ConfigurationManager.AppSettings["IProductRepository"];
            Type resolvedType = Type.GetType(typeName);
            object instance = Activator.CreateInstance(resolvedType);
            return instance as IProductRepository;
        }
    }
}
