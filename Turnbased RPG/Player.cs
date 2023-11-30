using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnbased_RPG
{
    internal class Player
    {
        public int Health = 3;
        public int Damage = 1;
        public int Potions = 2;
        public int Torches = 1;

       public void ShowStats()
        {
            Console.WriteLine($"Health: {Health} Potions: {Potions} Attack: {Damage} Torches: {Torches}");
        }
    }
}
