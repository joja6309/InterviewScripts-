using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastCalculator
{
    class BasicDimensions
    {
        public Tuple<double, double> Corner1;
        public Tuple<double, double> Corner2;
        public Tuple<double, double> Corner3;
        public Tuple<double, double> Corner4;
        public Tuple<double, double> Center = new Tuple<double, double>(0, 0);
        public double Height;
        public double Width;
        public double Xvalue;
        public double Yvalue;
        public void PrintAttributes()
        {
            Console.WriteLine("Corner 1: {0} ", Corner1);
            Console.WriteLine("Corner 2: {0} ", Corner2);
            Console.WriteLine("Corner 3: {0} ", Corner3);
            Console.WriteLine("Corner 4: {0} ", Corner4);
            Console.WriteLine("Center : {0}", Center);
            Console.WriteLine("Dimensions: ");
            Console.WriteLine("==================");
            Console.WriteLine("Width: {0}", Width);
            Console.WriteLine("Height: {0}", Height);
            Console.WriteLine(Environment.NewLine);

            Console.ReadKey();
            Console.WriteLine("Press Enter to Continue: ");
            Console.WriteLine(Environment.NewLine);


        }
       

    }
   
}
