using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1121
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero("Hero #1", 1, 300);
            Console.WriteLine(hero1.HeroInformation());

            Hero hero2 = new Hero("Hero #2", 1, 400);
            Console.WriteLine(hero2.HeroInformation());

        

            hero1.Attacked(hero2.Attack());
            Console.WriteLine(hero1.HeroInformation());

            hero1.Attacked(hero2.Attack());
            Console.WriteLine(hero1.HeroInformation());

            hero1.Attacked(hero2.Attack());
            Console.WriteLine(hero1.HeroInformation());

            hero1.Treatment();
            Console.WriteLine(hero1.HeroInformation());

        }
    }
}
