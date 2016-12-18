using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independent_notes
{
    public class Class1
    {
        private object _obj;
        private int _private_number = 3; 
        public Class1(object obj)
        {
            this._obj = obj; 
        }
        public object GetObject()
        {
            return this._obj; 
        }
        private void SetSomeThing(int private_number)
        {
            this._private_number += 2; 

        }
        public int get_number()
        {
            return this._private_number; 

        }








    }
}
