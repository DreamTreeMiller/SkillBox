using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1123
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero("Hero #2", 1, 100);
            Console.WriteLine(hero1.HeroInformation());

            for (int i = 0; i < 100; i++)
            {
                Hero hero2 = new Hero("Hero #1", 1, 100);
                Console.WriteLine(hero2.HeroInformation());
            }



            Console.ReadLine();
          
        }
    }
}
