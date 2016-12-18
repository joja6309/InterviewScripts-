using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Chose to implement interface within sorting dictionary implementation
/// The runtime of my original directoin was taking way to long so I chose to use .NET sortingdictionary library 
/// This library implements a tree structure for organization so values can be easily oredered on a particular attribute 
/// </summary>

namespace eBags.PileOfBeans.Haystack
{
    public class SortingTree : IHaystackOrganizer
    {
        public SortedDictionary<decimal, Straw> Red_Sorted { get; set; }
        public SortedDictionary<decimal, Straw> Blue_Sorted { get; set; }
        public SortedDictionary<decimal, Straw> Green_Sorted { get; set; }
        public SortedDictionary<decimal, Straw> Gray_Sorted { get; set; }

        public void TreeAdd(SortedDictionary<decimal, Straw> tree, Straw straw)
        {
            if (!tree.ContainsKey(straw.LengthInCm))
            {
                tree.Add(straw.LengthInCm, straw);
            }
            return;
        }


        public SortingTree()
        {
            Red_Sorted = new SortedDictionary<decimal, Straw>();
            Blue_Sorted = new SortedDictionary<decimal, Straw>();
            Green_Sorted = new SortedDictionary<decimal, Straw>();
            Gray_Sorted = new SortedDictionary<decimal, Straw>();

        }
        public SortByColorResult SortByColor(Haystack haystack)
        {

            // Red > Green > Blue 
            // Grey R = G = B 
            // If R = G, place in Red Bucket 
            // If G = B, place in Green Bucket --> Architecture of if-else statement will achieves this result
            // If B = R, place in Blue Bucket 
            // Order Straw list on length attribute -> Linq statement for ordering requirement
            // Remove Straw that is duplicated in length -> First OR default for non-duplicate check
            
    


        SortByColorResult sorted_pile = new SortByColorResult();
            SortingTree tree = new SortingTree();

            foreach (Straw straw in haystack.Pile)
            {
                int max_number = Math.Max(straw.ColorBlue, Math.Max(straw.ColorGreen, straw.ColorRed));
                if ((max_number == straw.ColorBlue) && (max_number == straw.ColorRed) && (max_number == straw.ColorGreen))
                {
                    this.TreeAdd(tree.Gray_Sorted, straw);

                }
                else if (max_number == straw.ColorRed)
                {
                    this.TreeAdd(tree.Red_Sorted, straw);

                }
                else if (max_number == straw.ColorGreen)
                {
                    this.TreeAdd(tree.Green_Sorted, straw);
                }
                else if (max_number == straw.ColorBlue)
                {
                    this.TreeAdd(tree.Blue_Sorted, straw);
                }

            }

            sorted_pile.Reds = new List<Straw>(tree.Red_Sorted.Values);
            sorted_pile.Blues = new List<Straw>(tree.Blue_Sorted.Values);
            sorted_pile.Greens = new List<Straw>(tree.Green_Sorted.Values);
            sorted_pile.Grays = new List<Straw>(tree.Gray_Sorted.Values);

            return sorted_pile;
        }

        }
    }
