using System;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace RolePlayV21
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            NumberGenerator generator = new NumberGenerator();
            BattleLog log = new BattleLog();

            // Battle logic (1-on-1)
            #region 1-on-1 battle logic
            Hero theHero = new Hero(generator, log, "Olafur", 300, 10, 30);
            Beast theBeast = new Beast(generator, log, "Zakhial", 90, 10, 25);

            // while (!theHero.Dead && !theBeast.Dead)
            // {
            //     int damageByHero = theHero.DealDamage();
            //     theBeast.ReceiveDamage(damageByHero);

            //     if (!theBeast.Dead)
            //     {
            //         int damageByBeast = theBeast.DealDamage();
            //         theHero.ReceiveDamage(damageByBeast);
            //     }
            // }

            // log.PrintLog();
            // Console.WriteLine();
            // if (theBeast.Dead)
            // {
            //     Console.WriteLine($"The Hero {theHero.Name} was Victorious!!");
            // }
            // else
            // {
            //     Console.WriteLine($"The Beast {theBeast.Name} won... ;-(");
            // }
            #endregion


            // New battle logic (1-on-many)
            #region 1-on-many battle logic

            BeastArmy beastArmy = new BeastArmy();
            Beast mikkel = new Beast(generator, log, "Mikkel", 15, 2, 4);
            Beast gleb = new Beast(generator, log, "Gleb", 11, 0, 100);
            beastArmy.AddBeast(mikkel);
            Beast simon = new Beast(generator, log, "Simon", 20, 8, 21);
            beastArmy.AddBeast(simon);
            beastArmy.AddBeast(gleb);
            beastArmy.AddBeast(theBeast);

            int heroWin = 0;
            int beastWin = 0;
            for(int i = 0; i<1000;i++)
            {
                while(!theHero.Dead && !beastArmy.Dead)
                {
                    int damageByHero = theHero.DealDamage();
                    beastArmy.ReceiveDamage(damageByHero);

                    if(!beastArmy.Dead)
                    {
                        int damageByBeast = beastArmy.DealDamage();
                        theHero.ReceiveDamage(damageByBeast);
                    }
                }
                if(beastArmy.Dead){
                    heroWin++;
                }else{
                    beastWin++;
                }
                theHero.Reset();
                mikkel.Reset();
                simon.Reset();
                gleb.Reset();
                theBeast.Reset();
            }
            Console.WriteLine($"The hero wins {heroWin} percent of the time and the army of beast wins {beastWin} percent of the time");
            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}