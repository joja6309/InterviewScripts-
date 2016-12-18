using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums_Intro
{
    class Program
    {
        enum Direction
        {
            NORTH, WEST, EAST, SOUTH
        };

        class Animal
        {
            public string name;
            public int age;
            public float happiness;
        }
        class Dog : Animal
        {
            public void Print()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Age: " + age);
                Console.WriteLine("Happiness: " + happiness);

            }
        }
        class KeyValuePair<TKey, TValue> // What ever is passed in is the type 
        {
            public TKey Key;
            public TValue Value;

            public KeyValuePair(TKey _key, TValue _value)
            {
                Key = _key;
                Value = _value;
            }
            public void Print()
            {
                Console.WriteLine("Key: " + Key.ToString());
                Console.WriteLine("Value: " + Value.ToString());


            }


        };
        class Utility
        {
            public static bool CompareValues<T01, T02>(T01 value01, T02 value02)
            {
                return value01.Equals(value02);
            }
            public static bool CompareTypes<T01, T02>(T01 type1, T02 type2)
            {
                return typeof(T01).Equals(typeof(T02));
            }


            static void Main(string[] args)
            {
                KeyValuePair<string, int> meaning = new KeyValuePair<string, int>("Life", 42);
                Dictionary<string, int> the_dic = new Dictionary<string, int>(5);
                the_dic.Add("Watermelon", 5);
                the_dic.Add("Car", 1000);
                meaning.Print();
                Console.WriteLine(Utility.CompareValues(10, 10));
                Console.WriteLine(Utility.CompareTypes(10, 3));
                Console.ReadKey();

            }
        }
    }
}
