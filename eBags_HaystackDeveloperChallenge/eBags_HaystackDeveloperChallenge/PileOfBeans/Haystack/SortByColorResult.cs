using System.Collections.Generic;
using System.Collections; 

namespace eBags.PileOfBeans.Haystack
{

    
    public class SortByColorResult
    {
        public IList<Straw> Reds { get; set; }
        public IList<Straw> Greens { get; set; }
        public IList<Straw> Blues { get; set; }
        public IList<Straw> Grays { get; set; }

      

        public SortByColorResult()
        {
            Reds = new List<Straw>();
            Blues = new List<Straw>();
            Greens = new List<Straw>();
            Grays = new List<Straw>();

        }
        
    }
}
