using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Turnbased_RPG
{
     class Monster
     {
         public int Health;
         public int Damage;

      public Monster(int health = 3, int damage = 1)
      {
          Health = health;
          Damage = damage;
      }
    }
}
