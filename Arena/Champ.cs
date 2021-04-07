using System;
using System.Collections.Generic;
using System.Text;

namespace Arena
{
    class Champ
    {
        public string name;
        public int hp;
        public int armor;
        public int dmg;
        public int initiative;
        public int attack;


        public Champ(string aName, int aHp, int aArmor, int aDmg, int aInitiative, int aAttack)
        {
            name = aName;
            hp = aHp;
            armor = aArmor;
            dmg = aDmg;
            initiative = aInitiative;
            attack = aAttack;
        }

        public void show()
        {
            Console.WriteLine("=============");
            Console.WriteLine("|| " + name + " ||");
            Console.WriteLine("=============");
            Console.WriteLine("|| HP: " + hp + " ||");
            Console.WriteLine("|| Arm: " + armor + " ||");
            Console.WriteLine("|| Dmg: " + dmg + " ||");
            Console.WriteLine("|| In: " + initiative + "  ||");
            Console.WriteLine("|| Atc: " + attack + " ||");
            Console.WriteLine("==============");    
        }



    }

    

}
