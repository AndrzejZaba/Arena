using System;
using System.Threading;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Champ warior = new Champ("Warior", 10, 8, 5, 2, 3);
            Champ mage = new Champ("Mage", 10, 5, 3, 3, 5);
            Champ rouge = new Champ("Rouge", 10, 6, 4, 4, 4);

            presentCharacters(warior, mage, rouge);
            Champ ChampionOne = FirstChamp(warior, mage, rouge);
            Champ ChampionTwo = SecondChamp(ChampionOne, warior, mage, rouge);
            Thread.Sleep(2000);
            Console.Clear();
           
            HpArmorUpdate(ChampionOne);
            HpArmorUpdate(ChampionTwo);
            Console.WriteLine("\n\nSo now the fight begins: "); Thread.Sleep(1000);
            int i = 1;
            while (ChampionOne.hp > 0 && ChampionTwo.hp > 0)
            {
                Console.WriteLine("\n\nTURN " + i);
                int InitiativeRollResult = InitiativePhase(ChampionOne, ChampionTwo);
                
                attackUpdate(InitiativeRollResult, ChampionOne, ChampionTwo);
                Console.WriteLine(ChampionOne.name + "'s attack: " + ChampionOne.attack); Thread.Sleep(1000);
                Console.WriteLine(ChampionTwo.name + "'s attack: " + ChampionTwo.attack); Thread.Sleep(1000);
                int AttackRollResult = AttackPhase(ChampionOne, ChampionTwo);
                
                DamagePhase(AttackRollResult, ChampionOne, ChampionTwo);
                Thread.Sleep(1000);
                Console.Clear();
                HpArmorUpdate(ChampionOne);
                HpArmorUpdate(ChampionTwo);
                attackReduction(InitiativeRollResult, ChampionOne, ChampionTwo);
                i++;
               // Console.Clear();
            }
            FightResult(ChampionOne, ChampionTwo);
        }

        static void FightResult(Champ championOne, Champ championTwo)
        {
            if (championOne.hp > 0 && championTwo.hp <= 0) Console.WriteLine("\n\n" + championOne.name + " won this fight!!!");
            if (championOne.hp <= 0 && championTwo.hp > 0) Console.WriteLine("\n\n" + championTwo.name + " won this fight!!!");
        }

        static void HpArmorUpdate(Champ championOne)
        {
            Console.WriteLine(championOne.name);
            for (int i = 0; i < championOne.hp; i++) Console.Write("* ");
            Console.WriteLine("\n");
            for (int i = 0; i < championOne.armor; i++) Console.Write("# ");
            Console.WriteLine("\n");

        }

        static void attackReduction(int RollResult, Champ championOne, Champ championTwo)
        {
            if(RollResult > 0)
            {
                championOne.attack--;
            }
            else if(RollResult < 0)
            {
                championTwo.attack--;
            }
        }

        static void attackUpdate(int InitiativeRollResult, Champ championOne, Champ championTwo)
        {
            if (InitiativeRollResult > 0)
            {
                championOne.attack++;
                Console.WriteLine(championOne.name + "'s attack has been boosted by 1"); Thread.Sleep(1000);   
                //Console.WriteLine("Current " + championOne.name + "'s attack equals: " + championOne.attack);  
            }
            else if (InitiativeRollResult < 0)
            {
                championTwo.attack++;
                Console.WriteLine(championTwo.name + "'s attack has been boosted by 1"); Thread.Sleep(1000);   
                //Console.WriteLine("Current " + championTwo.name + "'s attack equals: " + championTwo.attack);  
            }
            else Console.WriteLine("Nobody's akack has been boosted - Initatives rolls were equal"); Thread.Sleep(1000);
        }

        static Champ FirstChamp(Champ one, Champ two, Champ three)
        {
            Champ champion = new Champ("aa", 0, 0, 0, 0, 0);
            

            Console.WriteLine("Choose the first fighter: ");
            Console.WriteLine("1." + one.name + "\t2." + two.name + "\t3." + three.name);
            int ChampNum = Convert.ToInt32(Console.ReadLine());

            switch (ChampNum)
            {
                case 1:
                    champion = one;
                    break;
                case 2:
                    champion = two;
                    break;
                case 3:
                    champion = three;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Your Champion is " + champion.name);
            return champion;
        }

        static Champ SecondChamp(Champ taken, Champ one, Champ two, Champ three)
        {
            int ChampNum = 0;
            Champ champion = new Champ("a", 0, 0, 0, 0, 0);
            Console.WriteLine("Choose the second fighter: ");

            if(taken == one)
            {
                Console.WriteLine("1." + two.name + "\t2." + three.name);
                ChampNum = Convert.ToInt32(Console.ReadLine());
                switch(ChampNum)
                {
                    case 1:
                        champion = two;
                        break;
                    case 2:
                        champion = three;
                            break;
                    default:
                        break;
                }
            }else if(taken == two)
            {
                Console.WriteLine("1." + one.name + "\t2." + three.name);
                ChampNum = Convert.ToInt32(Console.ReadLine());
                switch (ChampNum)
                {
                    case 1:
                        champion = one;
                        break;
                    case 2:
                        champion = three;
                        break;
                    default:
                        break;
                }
            }else
            {
                Console.WriteLine("1." + one.name + "\t2." + two.name);
                ChampNum = Convert.ToInt32(Console.ReadLine());
                switch (ChampNum)
                {
                    case 1:
                        champion = one;
                        break;
                    case 2:
                        champion = two;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Your Champion is " + champion.name);
            return champion;
        }

        static void presentCharacters(Champ one, Champ two, Champ three)
        {
            Console.WriteLine("=============\t\t=============\t\t=============");
            Console.WriteLine("|| " + one.name + " ||\t\t|| " + two.name + " ||\t\t|| " + three.name + " ||");
            Console.WriteLine("=============\t\t=============\t\t=============");
            Console.WriteLine("|| HP: " + one.hp + " ||\t\t|| HP: " + two.hp + " ||\t\t|| HP: " + three.hp + " ||");
            Console.WriteLine("|| Arm: " + one.armor + " ||\t\t|| Arm: " + two.armor + " ||\t\t|| Arm: " + three.armor + " ||");
            Console.WriteLine("|| Dmg: " + one.dmg + " ||\t\t|| Dmg: " + two.dmg + " ||\t\t|| Dmg: " + three.dmg + " ||");
            Console.WriteLine("|| In: " + one.initiative + "  ||\t\t|| In: " + two.initiative + "  ||\t\t|| In: " + three.initiative + "  ||");
            Console.WriteLine("|| Atc: " + one.attack + " ||\t\t|| Atc: " + two.attack + " ||\t\t|| Atc: " + three.attack + " ||");
            Console.WriteLine("=============\t\t=============\t\t=============");
        }

        static int InitiativePhase(Champ one, Champ two)
        {
            Console.WriteLine("Initiative dices roll: "); Thread.Sleep(1000);
            Console.WriteLine(one.name + "'s roll: "); Thread.Sleep(500);
            int[] tab = initiativeRoll(one);
            int Sum1=0, Sum2=0;
            for (int i = 0; i < one.initiative; i++)
            {
                Console.Write(tab[i] + "\t");
                Sum1 = Sum1 + tab[i];
            }
            Console.WriteLine("\nSum of " + one.name + "'s roll is: " + Sum1); Thread.Sleep(2000);
            // Next Champion's roll of initiative -- for sure can be changed and simplified in the future
            Console.WriteLine("\n" + two.name + "'s roll: "); Thread.Sleep(500);
            tab = initiativeRoll(two);
            for (int i = 0; i < two.initiative; i++)
            {
                Console.Write(tab[i] + "\t");
                Sum2 = Sum2 + tab[i];
            }
            Console.WriteLine("\nSum of " + two.name + "'s roll is: " + Sum2); Thread.Sleep(2000);
            //=============================================================================

            return Sum1 - Sum2;
        }

        static int[] initiativeRoll(Champ one)
        {
            int[] roll = new int[one.initiative];
            Random rnd = new Random();

            for (int i=0;i<one.initiative;i++)
            {
                roll[i] = rnd.Next(1, 7);
            }
            return roll; 
        }

        static int[] attackRoll(Champ championOne)
        {
            int[] roll = new int[championOne.attack];
            Random rnd = new Random();

            for (int i = 0; i < championOne.attack; i++)
            {
                roll[i] = rnd.Next(1, 7);
            }
            return roll;
        }

        private static int AttackPhase(Champ championOne, Champ championTwo)
        {
            Console.WriteLine("\nAnd now begins ATTACK PHASE \n"); Thread.Sleep(1000);
            Console.WriteLine(championOne.name + "'s attack roll: "); Thread.Sleep(1000);
            int[] tab1 = new int[championOne.attack];
            tab1 = attackRoll(championOne);
            int succesSumOne = 0;
            for (int i = 0; i < championOne.attack; i++)
            {
                Console.Write(tab1[i] + "\t");
                if (tab1[i] >= 5) succesSumOne++; 
            }
            Thread.Sleep(2000);
            Console.WriteLine("\n" + championTwo.name + "'s attack roll: "); Thread.Sleep(1000);
            int[] tab2 = new int[championTwo.attack];
            tab2 = attackRoll(championTwo);
            int succesSumTwo = 0;
            for (int i = 0; i < championTwo.attack; i++)
            {
                Console.Write(tab2[i] + "\t");
                if (tab2[i] >= 5) succesSumTwo++;
            }
            int sumResult = succesSumOne - succesSumTwo;
            Thread.Sleep(2000);
            if (sumResult > 0)
            {
                Console.WriteLine("\n" + championOne.name + " won this phase and deals " + championOne.dmg + " damage points"); Thread.Sleep(2000);
                //Console.WriteLine("=======" + sumResult + "=======");
                return sumResult;
            }
            else if (sumResult < 0)
            {
                Console.WriteLine("\n" + championTwo.name + " won this phase and deals " + championTwo.dmg + " damage points"); Thread.Sleep(2000);
                //Console.WriteLine("=======" + sumResult + "=======");
                return sumResult;
            }
            else if (sumResult == 0)
            {
                Console.WriteLine("\nBoth numbers of succeses are equal so we need to roll for attack again: \n"); Thread.Sleep(2000);
                return AttackPhase(championOne, championTwo);
            }
            return sumResult;
        }

        static void DamagePhase(int SuccesResult, Champ championOne, Champ championTwo)
        {
            if (SuccesResult > 0)
            {
                for (int i = 0; i < championOne.dmg; i++)
                {
                    if(championTwo.armor > 0)       //surely can be wrote better - think about it in the future (dealing dmg system)
                    {
                        championTwo.armor--;
                        if (championTwo.armor == 0) { Console.WriteLine(championTwo.name + "'s armor broken"); } // to delete in the future
                    }
                    else { championTwo.hp--; }
                }
            }
            else if(SuccesResult < 0)
            {
                for (int i = 0; i < championTwo.dmg; i++)
                {
                    if (championOne.armor > 0)       //surely can be wrote better - think about it in the future (dealing dmg system)
                    {
                        championOne.armor--;
                        if (championOne.armor == 0) Console.WriteLine(championOne.name + "'s armor broken"); // to delete in the future
                    }
                    else { championOne.hp--; }
                }
            }
            Console.WriteLine("\nCurrent " + championOne.name + "'s HP: " + championOne.hp);
            Console.WriteLine("Current " + championOne.name + "'s Armor: " + championOne.armor);
            Console.WriteLine("Current " + championTwo.name + "'s HP: " + championTwo.hp);
            Console.WriteLine("Current " + championTwo.name + "'s Armor: " + championTwo.armor + "\n\n");
            Thread.Sleep(3000);
        }

    }



}
