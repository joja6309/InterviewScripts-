using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Independent_notes
{
    class Program
    {
        static void Main(string[] args)
        {

            Object empty_object = new Object(); 


            Class1 new_class = new Class1(empty_object);
            Console.WriteLine(new_class.get_number());

            IGeneric_Interface<string> container = new Generic_Class();
            Generic_Class other_definition = new Generic_Class(); 
            container.SetObject("test");
            Console.WriteLine(container.GetObject());
            container.SetObject("another test");
            Console.WriteLine(container.GetObject());
            string[] strArray = { "string one", "string two", "string three" };
            int[] intArray = { 123, 456, 789 };
            //Console.WriteLine(other_definition.ArrayContains<string>(strArray, "string one")); // True
            //Console.WriteLine(container.ArrayContains<int>(intArray, 135)); // False



            Console.ReadKey(); 
        }
    }
}
