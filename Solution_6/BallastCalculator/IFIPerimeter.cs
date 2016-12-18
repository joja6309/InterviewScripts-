using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastCalculator
{
    class IFIPerimeter : BasicDimensions
    {
        public Tuple<double, double> NE_corner = new Tuple<double, double>(0, 0);
        public Tuple<double, double> NW_corner = new Tuple<double, double>(0, 0);

        public void SetCorners()
        {
            List<Tuple<double, double>> corner_list = new List<Tuple<double, double>>();
            corner_list.Add(Corner1);
            corner_list.Add(Corner2);
            corner_list.Add(Corner3);
            corner_list.Add(Corner4);
            var max_x = corner_list[0].Item1;
            var max_y = corner_list[0].Item2;
            var min_x = corner_list[0].Item1;
            foreach (var x in corner_list)
            {
                if (x.Item1 >= max_x)
                {
                    max_x = x.Item1;

                }
                if (x.Item2 >= max_y)
                {
                    max_y = x.Item2;
                }
                if (x.Item1 <= min_x)
                {
                    min_x = x.Item1;
                }

            }
            if ((Corner1.Item1 == max_x) && (Corner1.Item2 == max_y))
            {
                NW_corner = Corner1;

            }
            else if ((Corner2.Item1 == max_x) && (Corner2.Item2 == max_y))
            {
                NW_corner = Corner2;
            }
            else if ((Corner3.Item1 == max_x) && (Corner3.Item2 == max_y))
            {
                NW_corner = Corner3;
            }
            else
            {
                NW_corner = Corner4;
            }

            if ((Corner1.Item1 == min_x) && (Corner1.Item2 == max_y))
            {
                NE_corner = Corner1;

            }
            else if ((Corner2.Item1 == min_x) && (Corner2.Item2 == max_y))
            {
                NE_corner = Corner2;
            }
            else if ((Corner3.Item1 == min_x) && (Corner3.Item2 == max_y))
            {
                NE_corner = Corner3;
            }
            else
            {
                NE_corner = Corner4;
            }

            return;

        }

        public void PrintIFIData()
        {

            Console.WriteLine("IFI Values:");
            Console.WriteLine("============");
            PrintAttributes();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("IFI Corners: ");
            Console.WriteLine("North East Corner: {0}", NE_corner);
            Console.WriteLine("North west Corner: {0}", NW_corner);
            Console.WriteLine(Environment.NewLine);

        }

        public void CalculateIFICenter()
        {
            double x1, x2, y1, y2;
            if (!(Corner1.Item1.Equals(Corner2.Item1)) && !(Corner1.Item2.Equals(Corner2.Item2)))
            {
                x1 = Corner1.Item1;
                x2 = Corner2.Item1;

                y1 = Corner1.Item2;
                y2 = Corner2.Item2;

            }

            else if (!(Corner1.Item1.Equals(Corner3.Item1)) && !(Corner1.Item2.Equals(Corner3.Item2)))

            //Corrected 

            {
                x1 = Corner1.Item1;
                x2 = Corner3.Item1;

                y1 = Corner1.Item2;
                y2 = Corner3.Item2;

            }
            else
            {
                x1 = Corner1.Item1;
                x2 = Corner4.Item1;

                y1 = Corner1.Item2;
                y2 = Corner4.Item2;

            }

            Width = x2 - x1;
            Height = y2 - y1;
            var x0 = x2;
            var y0 = y2;
            //KB NOTE: Extra variables added to identify fixed corner (NE corner) and then to be used in finding center consistently.
            if (Width < 0)
            {
                Width = Width * -1;
                x0 = x1;
            }
            if (Height < 0)
            {
                Height = Height * -1;
                y0 = y1;
            }


            // KB NOTE: changed Center so that it is always calculated from NE corner (largest x and largest y in block)
            Center = new Tuple<double, double>((x0 - (Width / 2)), (y0 - (Height / 2)));
           


        }



    }
}
    
