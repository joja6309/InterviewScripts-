using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSolution.Models
{
   
        public interface IWordQuery
        {
            void Add(WordQuery item);
            IEnumerable<WordQuery> GetAll();
             WordQuery Find(string key);
             WordQuery Remove(string key);
            void Update(WordQuery item);
        }
    
}
