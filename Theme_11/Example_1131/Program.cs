using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1131
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ролик 3. Наследование

            Console.WriteLine("Начальные характеристики");

            Druid druid = new Druid("druid", 1, 100); Console.WriteLine(druid.HeroInformation());

            Warrior warrior = new Warrior("warrior", 1, 100); Console.WriteLine(warrior.HeroInformation());

            Hunter hunter = new Hunter("hunter", 1, 100); Console.WriteLine(hunter.HeroInformation());

            Console.WriteLine("\nПосле атаки");

            druid.Attacked(50); Console.WriteLine(druid.HeroInformation());

            warrior.Attacked(50); Console.WriteLine(warrior.HeroInformation());

            hunter.Attacked(50); Console.WriteLine(hunter.HeroInformation());

            Console.WriteLine("\nПосле лечения");

            druid.Treatment(20); Console.WriteLine(druid.HeroInformation());

            warrior.Treatment(20); Console.WriteLine(warrior.HeroInformation());

            hunter.Treatment(20); Console.WriteLine(hunter.HeroInformation());

        }
    }
}
