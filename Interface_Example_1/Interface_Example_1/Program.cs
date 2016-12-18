using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example_1
{
    class MainClass
    {


        interface Iitem
        {
            //only data type for properties 
            string name { get; set; }
            int goldValue { get; set; }
            void Equip();
            void Sell();
        }
        interface IDamagable
        { 
            int durability{ get; set; }
            void TakeDamage(int _amount);
       
        }
        class Sword : Iitem, IDamagable 
        {
            public string name { get; set; }
            public int goldValue { get; set; }
            public int durability { get; set; } 
          
            public Sword(string _name)
            {
                name = _name;
                goldValue = 100;
            }
            public void TakeDamage(int _dmg)
            {
                durability = _dmg;
                Console.WriteLine(name + " damaged "); 
            }


            public void Equip()
            {
                Console.WriteLine(name + " equipped");

            }
            public void Sell()
            {
                Console.WriteLine(name + " sold for " + goldValue + " Value");
            }
        }

        public static void Main(string[] args)
        {

            Sword sword = new Sword("destiny");
            sword.Equip();
            sword.Sell();
            Console.ReadKey();
        }
    }
}


