using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastCalculator
{
    class PanelBase  :BasicDimensions 
    {
        public int BaseID; 
        public int PanelID;
        public int EdgeID;
        public int LoadShare;
        public double LoadValue;
        public double NE_Zone = 0;
    }
}
