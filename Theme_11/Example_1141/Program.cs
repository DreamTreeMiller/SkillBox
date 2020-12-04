using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1141
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.Unicode;

			// Ролик 4.Полиморфизм

			#region Команда

			//// Создать 20 случайных героев

			//int count = 10;

			//Random r = new Random();

			//int countDruid = r.Next(0, count);
			//int countHunter = r.Next(0, count - countDruid);
			//int countWarrior = count - countDruid - countHunter;

			//Console.WriteLine($"countDruid: {countDruid} countHunter: {countHunter} countWarrior: {countWarrior}");

			//List<Druid> druids = new List<Druid>();

			//for (int i = 0; i < countDruid; i++)
			//{
			//	druids.Add(new Druid());
			//	Console.WriteLine(druids[i].HeroInformation());
			//	druids[i].Motto();

			//}

			//Console.WriteLine();
			//List<Hunter> hunters = new List<Hunter>();

			//for (int i = 0; i < countHunter; i++)
			//{
			//	hunters.Add(new Hunter());
			//	Console.WriteLine(hunters[i].HeroInformation());
			//	hunters[i].Motto();
			//}

			//Console.WriteLine();
			//List<Warrior> warriors = new List<Warrior>();

			//for (int i = 0; i < countWarrior; i++)
			//{
			//	warriors.Add(new Warrior());
			//	Console.WriteLine(warriors[i].HeroInformation());
			//	warriors[i].Motto();
			//}

			#endregion

			#region Полиморфизм

			//Hero hero = new Hero(); Console.WriteLine(hero.HeroInformation());
			//hero = new Druid(); Console.WriteLine(hero.HeroInformation());
			//hero = new Hunter(); Console.WriteLine(hero.HeroInformation());
			//hero = new Warrior(); Console.WriteLine(hero.HeroInformation());

			#endregion

			#region is as

			//Hero hero = new Hero(); Console.WriteLine(hero.HeroInformation());
			//hero = new Druid(); Console.WriteLine(hero.HeroInformation());


			//((Druid)hero).Heal();

			//(hero as Druid).Heal();

			#endregion

			#region Команда с полиморфизмом

			Random r = new Random();

			List<Hero> heroes = new List<Hero>();

			for (int i = 0; i < 10; i++)
			{
				switch (r.Next(3))
				{
					case 0: heroes.Add(new Druid()); break;
					case 1: heroes.Add(new Hunter()); break;
					default: heroes.Add(new Warrior()); break;
				}

				Console.WriteLine(heroes[i]);

				#region _

				//(heroes[i] as Druid).Heal();

				#region 


				if (heroes[i] is Druid) (heroes[i] as Druid).Heal();
				if (heroes[i].GetType() == typeof(Druid)) ((Druid)heroes[i]).Heal();

				#endregion

				#endregion


				heroes[i].Motto();
			}

			#endregion


		}
    }
}
