using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastCalculator
{




     class PanelGrid: Panel
    {

      public PanelGrid(BasicDimensions perimeter, List<Panel> plist)
        {
            PanelList = plist;
            IFIBoarder = perimeter; 
        }

        BasicDimensions IFIBoarder = new BasicDimensions();

        private List<Panel> PanelList = new List<Panel>();

        private List<PanelBase> PanelBaseList = new List<PanelBase>();

        public void CalculateNeighbors(int input_n)
        {


           foreach(Panel panel in PanelList)
            {
                var x_start = Center.Item1;
                var y_start = Center.Item2;
                var neighborhood = GenerateNeighborhood(input_n, x_start, y_start);

                foreach (var neighbor in neighborhood)
                {
                    foreach (var x in PanelList)
                    {


                        if ((Math.Abs(neighbor.Item1 - x.Center.Item1) <= .5) && (Math.Abs(neighbor.Item2 - x.Center.Item2) <= .5))
                        {
                            panel.NeighborHood.Add(x);

                        }
                    }
                }

            }
                

        }
        private List<Tuple<double, double>> GenerateNeighborhood(int input_n, double x_start, double y_start)
        {

            List<Tuple<double, double>> neighborhood = new List<Tuple<double, double>>();


            for (int x = 0; x <= input_n; x++)
            {
                for (int y = 0; y <= input_n; y++)
                {
                    for (int i = -1; i <= 1; i += 2)
                    {
                        if (x.Equals(0))
                            i = 1;


                        for (int j = -1; j <= 1; j += 2)
                        {
                            if (y.Equals(0))
                                j = 1;


                            Tuple<double, double> temp_neighbor = new Tuple<double, double>(x_start + (0.5 + IFIBoarder.Width) * i * x, y_start + (17.494 + IFIBoarder.Height) * j * y);
                            neighborhood.Add(temp_neighbor);
                        }

                    }
                }
            }

            
            return neighborhood;

        }

        public void PrintPanelData()
        {
            Console.WriteLine("Panel/Entities Values:");
            Console.WriteLine("======================");
            foreach (var x in PanelList)
            {
                Console.WriteLine("Panel Number {0}: ", x.PanelID);
                Console.WriteLine("X value: {0}", x.Xvalue.ToString());
                Console.WriteLine("Y Value: {0} ", x.Yvalue.ToString());
                Console.WriteLine("Center Value: {0}", x.Center.ToString());
                Console.WriteLine("North East Zone: {0}", x.NE_Zone.ToString());
                Console.WriteLine("North West Zone: {0}", x.NW_Zone.ToString());
                Console.WriteLine("Neighbor List: ");
                Console.WriteLine("=================");
                foreach (var neighbor in x.NeighborHood)
                {
                    Console.WriteLine("Neighbor ID: {0} ", neighbor.PanelID);
                }
                Console.WriteLine("=================");
                Console.WriteLine("\n");

            }

            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadKey();


            return;
        }

    }
}
