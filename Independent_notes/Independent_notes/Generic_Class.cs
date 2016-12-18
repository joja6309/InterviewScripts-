using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independent_notes
{
    public class Generic_Class : IGeneric_Interface<string>
    {
        private string _str; 
        public string GetObject()
        {
            return _str;
        }
        public void SetObject(string value)
        {
            _str = value; 
        }
        public static bool ArrayContaines<T>(T[] array, T element)
        {
            foreach( T e in array)
            {
                if (e.Equals(element))
                {
                    return true;
                }
            }
            return false; 

        }


       
            
    }
    //public class FileWithString : IGeneric_Interface<string>
    //{
    //        ...
    //    }
}
