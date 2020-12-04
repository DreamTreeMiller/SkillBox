using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Example_1212
{
	struct MyStruct
	{
		int fInt;
		string fString;
	}

	struct MyStruct2
	{
		int fInt;
		string fString;
		bool fBool;
	}
	interface ICompareMyClass<in T>
	{
		int CompareMS(T x);
	}

	class MyClass1 : ICompareMyClass<MyClass1>
	{
		public string color;

		public int CompareMS(MyClass1 y)
		{
			if (this.color == y.color) return 0;
			if (this.color == "red" || y.color == "black") return 1; // red is bigger than any other color
			if (this.color == "black" || y.color == "red") return -1; // black is smaller than any other color
			return this.color.CompareTo(y.color);
		}

		public override string ToString()
		{
			return color;
		}
	}

	class MyClass2<T> 
	{
		public string Check(T x, T y)
		{
			
			if ((x as ICompareMyClass<T>).CompareMS(y) < 0) return $"{x} is smaller than {y}";
			if ((x as ICompareMyClass<T>).CompareMS(y) > 0) return $"{x} is bigger than {y}";
			return $"{x} is equal to {y}";
		}



	}

	public class IterateSpanExample
	{
		public static void Main()
		{
			System.Span<int> numbers = new int[] { 3, 14, 15, 92, 6 };
			foreach (int number in numbers)
			{
				Console.Write($"{number} ");
			}
			Console.WriteLine();
		}
	}

	//   class Program
	//   {
	//       static void Main(string[] args)
	//       {
	//           //Robot robot1 = new Robot("Robot_1", "Test");

	//           //var robots = new List<Robot> { new Robot("Robot_1", "Test") };

	//           //Robot robot2 = new Robot("Robot_1", "Test");
	//           //Console.WriteLine(robots.Contains(robot2));
	//           //Console.WriteLine(robots.Contains(robot1));


	//		MyClass1 red = new MyClass1() { color = "red" };
	//		MyClass1 black = new MyClass1() { color = "black" };
	//		MyClass1 yellow = new MyClass1() { color = "yellow" };
	//		MyClass1 red2 = new MyClass1() { color = "red" };
	//		MyClass1 white = new MyClass1() { color = "white" };
	//		MyClass2<MyClass1> test = new MyClass2<MyClass1>();


	//		Console.WriteLine(test.Check(red, black));
	//		Console.WriteLine(test.Check(red, red2));
	//		Console.WriteLine(test.Check(yellow, yellow));
	//		Console.WriteLine(test.Check(black, red));
	//		Console.WriteLine(test.Check(yellow, red));
	//		Console.WriteLine(test.Check(yellow, black));
	//		Console.WriteLine(test.Check(yellow, white));

	//		Console.ReadKey();

	//	}

	//}
}
