using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1471
{
	enum Gender 	{ M, F }
	class Person
	{
		public string FirstName;
		public string LastName;
		public Gender GND;
		public int	  Age;
		public bool	  Boss;

		public Person (string fn, string ln, Gender gnd, int age, bool boss)
		{
			FirstName	= fn;
			LastName	= ln;
			GND			= gnd;
			Age			= age;
			Boss		= boss;
		}

		public override string ToString()
		{
			return $" {FirstName,10} {LastName,10} {GND, 5} {Age,5} {(Boss? "Boss" : "Worker"),10}";
		}
	}
    delegate bool Compare(Person p, ref bool flag);

    class Program
    {
		static Random r = new Random();

        static void Main(string[] args)
        {
			#region Homework
			// Создать прототип банковской системы, позвляющей управлять клиентами и клиентскими счетами.
			// В информационной системе есть возможность перевода денежных средств между счетами пользователей
			// Открывать вклады, с капитализацией и без
			// * Продумать возможность выдачи кредитов
			// Продумать использование обобщений

			// Продемонстрировать работу созданной системы

			// Банк
			// ├── Отдел работы с обычными клиентами
			// ├── Отдел работы с VIP клиентами
			// └── Отдел работы с юридическими лицами

			// Дополнительно: клиентам с хорошей кредитной историей предлагать пониженую ставку по кредиту и 
			// повышенную ставку по вкладам
			// Добавить механизмы оповещений использую делегаты и события
			// Реализовать журнал действий, который будет хранить записи всех транзакций по 
			// счетам / вкладам / кредитам

			#endregion
			List<Person> people = GeneratePeople(1000);

			foreach (var p in people) Console.WriteLine(p);

			FNComparator FirstNameComparator = new FNComparator("2");
			Compare CheckFN = FirstNameComparator.Compare;

			LNComparator LastNameComparator = new LNComparator("3");
			Compare CheckLN = LastNameComparator.Compare;

			GNDComparator GenderComparator = new GNDComparator(Gender.F);
			Compare CheckGND = GenderComparator.Compare;

			IntComparator AgeComparator = new IntComparator(38);
			Compare CheckAge = AgeComparator.Compare;

			BossComparator BossComparator = new BossComparator(true);
			Compare CheckBoss = BossComparator.Compare;

			Compare checkAll;
			checkAll = null;// CheckFN;
			checkAll += CheckLN;
			checkAll += CheckGND;
			checkAll += CheckAge;
			checkAll += CheckBoss;

			bool flag;

			Console.WriteLine();
			Console.WriteLine("After comparison");
			Console.WriteLine();
			foreach(var p in people)
			{
				flag = true;
				flag = checkAll(p, ref flag);
				if (flag) Console.WriteLine(p);
			}




		}
		public static List<Person> GeneratePeople(int num)
		{
			List<Person> tmp = new List<Person>();
			for (int i = 0; i < num; i++)
				tmp.Add(new Person(
					"First_" + r.Next(0, 10_000).ToString(),
					"Last_" + r.Next(0, 10_000).ToString(),
					(Gender)r.Next(0, 2),
					r.Next(18, 100),
					r.Next(0, 2) == 1 ? true : false
					));
			return tmp;
		}

		void DoNothing() { }
	}

	class FNComparator
	{
		string objectToFind;

		public FNComparator(string value) { objectToFind = value; }

		public bool Compare(Person sourceP, ref bool flag)
		{
			if (!flag) return false;
			flag = sourceP.FirstName.Contains(objectToFind);
			return flag;
		}
	}

	class LNComparator
	{
		string objectToFind;

		public LNComparator(string value) { objectToFind = value; }

		public bool Compare(Person sourceP, ref bool flag)
		{
			if (!flag) return false;
			flag = sourceP.LastName.Contains(objectToFind);
			return flag;
		}
	}

	class GNDComparator
	{
		Gender objectToFind;

		public GNDComparator(Gender value) { objectToFind = value; }

		public bool Compare(Person sourceP, ref bool flag)
		{
			if (!flag) return false;
			flag = sourceP.GND == objectToFind;
			return flag;
		}
	}

	class IntComparator
	{
		int objectToFind;

		public IntComparator(int value) { objectToFind = value; }

		public bool Compare(Person sourceP, ref bool flag)
		{
			if (!flag) return false;
			flag = sourceP.Age == objectToFind;
			return flag;
		}
	}

	class BossComparator
	{
		bool objectToFind;

		public BossComparator(bool value) { objectToFind = value; }

		public bool Compare(Person sourceP, ref bool flag)
		{
			if (!flag) return false;
			flag = sourceP.Boss == objectToFind;
			return flag;
		}
	}

}
