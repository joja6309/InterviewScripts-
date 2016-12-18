using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBags.PileOfBeans.Haystack;

namespace Program
{


    class Program
    {
        
        static void Main(string[] args)
        {
            Haystack haystack = new Haystack();

            Utilities util = new Utilities();

            IHaystackOrganizer hay_organizer = new Haystack();

            var sorted_stack = hay_organizer.SortByColor(haystack);

           
            //foreach(var straw_piece in sorted_stack.Reds)
            //{
            //    Console.WriteLine("S:{0}", straw_piece.LengthInCm.ToString()); 
            //}
            
            Console.ReadKey(); 
           
            //HayStackOrganizer organizer = new HayStackOrganizer();
            //var test_stack_result = hay_organizer.SortByColor(haystack);

            //var test_green_duplicates = test_stack_result.Greens.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            //var test_blue_duplicates = test_stack_result.Blues.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            //var test_red_duplicates = test_stack_result.Reds.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            //var test_gray_duplicates = test_stack_result.Grays.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);

            //Console.WriteLine("Blue count {0}", test_blue_duplicates.Count());
            //Console.WriteLine("Red count {0}", test_red_duplicates.Count());
            //Console.WriteLine("Green count {0}", test_green_duplicates.Count());
            //Console.WriteLine("Gray count {0}", test_gray_duplicates.Count());
        }
    }
}
