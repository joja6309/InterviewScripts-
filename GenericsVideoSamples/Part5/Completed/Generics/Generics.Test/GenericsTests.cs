using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Generics.Common;

namespace Generics.Test
{
    public static class HelperMethods
    {
        public static T Max<T>(T value1, T value2) where T : IComparable
        {
            if (value1.CompareTo(value2) >= 0)
                return value1;
            else
                return value2;
        }
    }

    [TestClass]
    public class GenericsTests
    {
        [TestMethod]
        public void Max_WithInts_ReturnsHigherValue()
        {
            int result = HelperMethods.Max(23, 530);
            Assert.AreEqual(530, result);
        }

        [TestMethod]
        public void Max_WithDates_ReturnsLaterDate()
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime result = HelperMethods.Max(today, yesterday);
            Assert.AreEqual(DateTime.Today, result);
        }

        //[TestMethod]
        //public void Max_WithPerson_Returns___()
        //{
        //    Person personA = new Person();
        //    Person personB = new Person();
        //    Person result = HelperMethods.Max(personA, personB);

        //}

        [TestMethod]
        public void Default_Int_IsZero()
        {
            int defaultInt = default(int);
            Assert.IsNotNull(defaultInt);
            Assert.AreEqual(0, defaultInt);
        }

        [TestMethod]
        public void Default_DateTime_IsMinValue()
        {
            DateTime defaultDate = default(DateTime);
            Assert.IsNotNull(defaultDate);
            Assert.AreEqual(DateTime.MinValue, defaultDate);
        }

        [TestMethod]
        public void Default_List_IsNull()
        {
            List<Person> defaultList = default(List<Person>);
            Assert.IsNull(defaultList);
            Assert.AreEqual(null, defaultList);
        }
    }
}
