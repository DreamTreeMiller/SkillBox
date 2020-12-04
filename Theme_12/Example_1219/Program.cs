using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1219
{

    class SomethingA
    {
        public int[] array;
        public SomethingA() { array = Enumerable.Range(1, 10).ToArray(); }

		public int this[int index]
		{
			get { return this.array[index]; }
			set { this.array[index] = value; }
		}

		public int Count { get { return this.array.Length; } }

	}

    class SomethingB
    {
        int index;

        //  Возвращает элемент, соответствующий текущей позиции 
        public int Current() { return array[index]; }

        // Перемещает перечислитель к следующему элементу 
        public bool MoveNext()
        {
            return ++index < array.Length;
        }


        // Сводка:
        // Устанавливает перечислитель в его начальное положение, т. е. перед первым элементом
        public void Reset(){ index = -1; }


        int[] array;
        public SomethingB()
        {
            array = Enumerable.Range(11, 10).ToArray();
            index = -1;
        }

		public int this[int index]
		{
			get { return this.array[index]; }
			set { this.array[index] = value; }
		}

		public int Count { get { return this.array.Length; } }

	}

    class Program
    {

        static void Main(string[] args)
        {
			#region SomethingA

			var a = new SomethingA();
			for (int i = 0; i < a.Count; i++)
			{
				Console.Write($"{a[i],3} ");
			}
			Console.WriteLine();

			Console.ReadKey();

			#endregion

			#region SomethingB

			var b = new SomethingB();

			b.Reset();

			while (b.MoveNext())
			{
				Console.Write($"{b.Current(),3} ");
			}


			Console.WriteLine();

			b.Reset();

			while (b.MoveNext())
			{
				Console.Write($"{b.Current(),3} ");
			}

			Console.WriteLine();

			Console.ReadKey();
            #endregion

            
        }
    }
}
