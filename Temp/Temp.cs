using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
		class Person : IComparable
		{
			public string Name { get; set; }
			public int Age { get; set; }
			public int CompareTo(object o)
			{
				Person p = o as Person;
				if (p != null)
				{
					int result = Age.CompareTo(p.Age);
					if (result != 0)//если объекты не равны то будет число отлиное от нуля
					{
						return result;
					}
					return Name.CompareTo(p.Name);
				}

				else
					throw new Exception("Невозможно сравнить два объекта");
			}
		}

		public class KeyStruct : IComparable
		{
			public uint ID { get; private set; }
			public short Year { get; set; }
			public sbyte Month { get; set; }
			public sbyte Day { get; set; }

			public sbyte Hour { get; set; }
			public sbyte Min { get; set; }

			public int CompareTo(object o)
			{
				KeyStruct key = o as KeyStruct;
				int result = Year.CompareTo(key.Year);
				if (result != 0) return result;
				result = Month.CompareTo(key.Month);
				if (result != 0) return result;
				result = Day.CompareTo(key.Day);
				if (result != 0) return result;
				result = Hour.CompareTo(key.Hour);
				if (result != 0) return result;
				result = Min.CompareTo(key.Min);
				if (result != 0) return result;
				result = ID.CompareTo(key.ID);
				return result;
			}
			public KeyStruct(uint id, DateTime dt)
			{
				this.ID = id;
				this.Year = (short)dt.Year;
				this.Month = (sbyte)dt.Month;
				this.Day = (sbyte)dt.Day;
				this.Hour = (sbyte)dt.Hour;
				this.Min = (sbyte)dt.Minute;
			}

			public KeyStruct(uint id, short yyyy, sbyte mm, sbyte dd, sbyte hh, sbyte min)
			{
				this.ID = id;
				this.Year = yyyy;
				this.Month = mm;
				this.Day = dd;
				this.Hour = hh;
				this.Min = min;
			}

			public override string ToString()
			{
				return $"{this.Day,2:00}-{this.Month,2:00}-{this.Year,4} " +
					   $"{this.Hour,2:00}:{this.Min,2:00}";
			}
		}

		static void Main(string[] args)
        {
			SortedList<KeyStruct, string> Day = new SortedList<KeyStruct, string>(10);
			KeyStruct key;
			int i;
			uint[] id = { 2020, 1987, 4, 777, 3000, 45, 500, 12, 2783, 1648 };

			for (i = 0; i<10; i++)
			{
				key = new KeyStruct(id[i], 2020, 06, 22, 13, 43);
				Day.Add(key, $"This is string {i}");
			}

			foreach (var e in Day) Console.WriteLine($"{e.Key.ID, 4} " + $"{e.Value}");
			Console.WriteLine();



		}

	}
}
