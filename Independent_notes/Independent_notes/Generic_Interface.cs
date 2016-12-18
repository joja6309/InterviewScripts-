using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independent_notes
{
    public  interface IGeneric_Interface<T>
    {
        T GetObject();
        void SetObject(T value); 

    }

}
