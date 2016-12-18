using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace EmpSolution.Models
{
    public class WordQuery
    {
        public class TodoRepository : IWordQuery
        {
            private static ConcurrentDictionary<string, WordQuery> _todos =
                  new ConcurrentDictionary<string, WordQuery>();

            public TodoRepository()
            {
                Add(new WordQuery { Name = "Item1" });
            }

            public IEnumerable<WordQuery> GetAll()
            {
                return _todos.Values;
            }

            public void Add(WordQuery item)
            {
                item.Key = Guid.NewGuid().ToString();
                _todos[item.Key] = item;
            }

            public WordQuery Find(string key)
            {
                WordQuery item;
                _todos.TryGetValue(key, out item);
                return item;
            }

            public WordQuery Remove(string key)
            {
                WordQuery item;
                _todos.TryRemove(key, out item);
                return item;
            }

            public void Update(WordQuery item)
            {
                _todos[item.Key] = item;
            }
        }
    }
}
