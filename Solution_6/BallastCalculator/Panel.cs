using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastCalculator
{
    class Panel : BasicDimensions
    {
        public int PanelID;

        public List<PanelBase> PanelBases = new List<PanelBase>();
        public List<Panel> NeighborHood = new List<Panel>();

        public double NE_Zone = 0;
        public double NW_Zone = 0;



        public void SetPanelZones(IFIPerimeter perimeter)
        {
            

                if (((Math.Abs(perimeter.NW_corner.Item1 - Center.Item1)) < (787.402) && (Math.Abs(perimeter.NW_corner.Item2 - Center.Item2) < 787.402)))

                    NW_Zone = 1;


                else if ((Math.Abs(perimeter.NW_corner.Item1 - Center.Item1) < 787.402) && (Math.Abs(perimeter.NW_corner.Item2 - Center.Item2) > 787.402))

                    NW_Zone = 2;


                else if (Math.Abs(perimeter.NW_corner.Item1 - Center.Item1) < 1574.804)

                    NW_Zone = 3;


                else if (Math.Abs(perimeter.NW_corner.Item1 - Center.Item1) < 2362.206)

                    NW_Zone = 4;

                else

                    NW_Zone = 5;
                if ((Math.Abs(perimeter.NE_corner.Item1 - Center.Item1) < 787.402) && (Math.Abs(perimeter.NE_corner.Item2 - Center.Item2) < 787.402))

                    NE_Zone = 1;


                else if ((Math.Abs(perimeter.NE_corner.Item1 - Center.Item1) < 787.402) && (Math.Abs(perimeter.NE_corner.Item2 - Center.Item2) > 787.402))

                    NE_Zone = 2;


                else if (Math.Abs(perimeter.NE_corner.Item1 - Center.Item1) < 1574.804)

                    NE_Zone = 3;


                else if (Math.Abs(perimeter.NE_corner.Item1 - Center.Item1) < 2362.206)

                    NE_Zone = 4;

                else

                    NE_Zone = 5;

            

        }

        public void CalculatePanelCenter(double center_x, double center_y)
        {
            Center = new Tuple<double, double>((Xvalue + center_x), (Yvalue + center_y));

        }
    }



}
