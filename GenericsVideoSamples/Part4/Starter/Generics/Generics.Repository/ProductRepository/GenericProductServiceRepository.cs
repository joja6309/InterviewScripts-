using System;
using System.Collections.Generic;
using Generics.Common;
using Generics.Common.Interface;

namespace Generics.Repository.ProductRepository
{
    public class GenericProductServiceRepository : IRepository<Product, int>
    {
        public IEnumerable<Product> GetItems()
        {
            throw new NotImplementedException();
        }

        public Product GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public void AddItem(Product newItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int key, Product updatedItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int key)
        {
            throw new NotImplementedException();
        }

        public void UpdateItems(IEnumerable<Product> updatedItems)
        {
            throw new NotImplementedException();
        }
    }
}
