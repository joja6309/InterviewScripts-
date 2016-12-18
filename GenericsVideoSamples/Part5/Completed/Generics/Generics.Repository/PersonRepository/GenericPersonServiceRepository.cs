using System.Collections.Generic;
using System.Linq;
using Generics.Common;
using Generics.Common.Interface;
using Generics.Repository.MyService;

namespace Generics.Repository.PersonRepository
{
    public class GenericPersonServiceRepository : IRepository<Person, string>
    {
        private PersonServiceClient proxy;

        public GenericPersonServiceRepository()
        {
            proxy = new PersonServiceClient();
        }

        public IEnumerable<Person> GetItems()
        {
            return proxy.GetPeople();
        }

        public Person GetItem(string key)
        {
            return proxy.GetPerson(key);
        }

        public void AddItem(Person newItem)
        {
            proxy.AddPerson(newItem);
        }

        public void UpdateItem(string key, Person updatedItem)
        {
            proxy.UpdatePerson(key, updatedItem);
        }

        public void DeleteItem(string key)
        {
            proxy.DeletePerson(key);
        }

        public void UpdateItems(IEnumerable<Person> updatedItems)
        {
            proxy.UpdatePeople(updatedItems.ToArray());
        }
    }
}
