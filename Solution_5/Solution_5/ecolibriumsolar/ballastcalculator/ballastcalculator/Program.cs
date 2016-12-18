using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace BallastCalculator
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Input Landscape or Portrait Mode (l/p)");
            string input = Console.ReadLine();
            Console.WriteLine("Input with deflector or without deflector (w/wo)");
            string input2 = Console.ReadLine();
            Console.WriteLine("Press Enter to Continue: ");
            DxfParser file_data = new DxfParser("fileName");
            file_data.ParseFile();
            file_data.OutPutData(); 
            
            
        }
    }
}
