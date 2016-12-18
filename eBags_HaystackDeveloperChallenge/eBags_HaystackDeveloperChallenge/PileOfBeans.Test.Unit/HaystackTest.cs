using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace eBags.PileOfBeans.Test.Unit
{

    using Haystack;

    [TestClass]
    public class HaystackTest
    {
      
        [TestMethod]
        public void Correct_Pile_test()
        {
            Haystack haystack = new Haystack();

            IHaystackOrganizer hay_organizer = new SortingTree();

            SortByColorResult sorted_stack = hay_organizer.SortByColor(haystack);

            foreach(var x in sorted_stack.Blues)
                {
                int max_number = Math.Max(x.ColorBlue, Math.Max(x.ColorGreen, x.ColorRed));

                Assert.AreEqual(x.ColorBlue, max_number, "Failed: Blue stack has color that does not belong");
               
            }
            foreach (var x in sorted_stack.Greens)
            {
                int max_number = Math.Max(x.ColorBlue, Math.Max(x.ColorGreen, x.ColorRed));

                Assert.AreEqual(x.ColorGreen, max_number, "Failed: Green stack has color that does not belong");

            }
            foreach (var x in sorted_stack.Reds)
            {
                int max_number = Math.Max(x.ColorBlue, Math.Max(x.ColorGreen, x.ColorRed));

                Assert.AreEqual(x.ColorRed, max_number, "Failed: Red stack has color that does not belong");

            }
            foreach (var x in sorted_stack.Grays)
            {
                
                Assert.AreEqual(x.ColorBlue, x.ColorGreen, "Failed: Gray stack has straw that does not have equal green/blue/red values ");
                Assert.AreEqual(x.ColorBlue, x.ColorRed, "Failed: Gray stack has straw that does not have equal green/blue/red values ");

            }

        }
        [TestMethod]
        public void Incrementing_Values_test()
        {
            Haystack haystack = new Haystack();

            IHaystackOrganizer hay_organizer = new SortingTree();

            var sorted_stack = hay_organizer.SortByColor(haystack);

            decimal less_than = 0;

            foreach (var x in sorted_stack.Greens)
            {
                if (less_than == 0)
                {
                    less_than = x.LengthInCm;
                    continue;
                }
                if (less_than >= x.LengthInCm)
                {
                    Assert.Fail("Fail: Green list does not increment from smallest to largest straw length");

                }
                if (x == sorted_stack.Greens.Last())
                {
                    less_than = 0;
                }

            }

            foreach (var x in sorted_stack.Blues)
            {
                if (less_than == 0)
                {
                    less_than = x.LengthInCm;
                    continue;
                }
                if (less_than >= x.LengthInCm)
                {
                    Assert.Fail("Fail: Blue list does not increment from smallest straw length to largest strawa length");

                }
                if (x == sorted_stack.Blues.Last())
                {
                    less_than = 0;
                }

            }
            foreach (var x in sorted_stack.Reds)
            {
                if (less_than == 0)
                {
                    less_than = x.LengthInCm;
                    continue;
                }
                if (less_than >= x.LengthInCm)
                {
                    Assert.Fail("Fail: Red list does notincrement from smallest straw length to largest straw length");

                }
                if (x == sorted_stack.Reds.Last())
                {
                    less_than = 0;
                }

            }
            foreach (var x in sorted_stack.Grays)
            {
                if (less_than == 0)
                {
                    less_than = x.LengthInCm;
                    continue;
                }
                if (less_than >= x.LengthInCm)
                {
                    Assert.Fail("Fail: Gray list does not increment from smallest straw length to largest strawa length");

                }
                if (x == sorted_stack.Grays.Last())
                {
                    less_than = 0;
                }

            }
        }

        [TestMethod]
        public void No_Repeates_test()
        {
            Haystack haystack = new Haystack();

          
            IHaystackOrganizer hay_organizer = new SortingTree();

            var sorted_stack = hay_organizer.SortByColor(haystack);
            var green_list = sorted_stack.Greens;
            var blue_list = sorted_stack.Blues;
            var red_list = sorted_stack.Reds;
            var gray_list = sorted_stack.Grays; 

            // Fill the list

            if (green_list.Count != green_list.Distinct().Count())
            {
                // Duplicates exist
                Assert.Fail("Fail: Green list does not increment from smallest straw length to largest strawa length");

            }
            if (blue_list.Count != blue_list.Distinct().Count())
            {
                // Duplicates exist
                Assert.Fail("Fail: Blue list does not increment from smallest straw length to largest strawa length");

            }
            if (red_list.Count != red_list.Distinct().Count())
            {
                // Duplicates exist
                Assert.Fail("Fail: Red list does not increment from smallest straw length to largest strawa length");

            }
            if (gray_list.Count != gray_list.Distinct().Count())
            {
                // Duplicates exist
                Assert.Fail("Fail: Gray list does not increment from smallest straw length to largest strawa length");

            }

        }

    }
}