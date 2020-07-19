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
			List<int> test = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 15, 15, 15, 15, 15, 17};

			Console.WriteLine(test.FindIndex(0, 13, delegate (int x) { return x == 9; }));



		}

	}
}
