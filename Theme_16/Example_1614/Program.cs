using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1614
{
    class Bag
    {
        public Bag(int i, string s, double d)
        {
            this.MyProperty1 = i;
            this.MyProperty2 = s;
            this.MyProperty3 = d;
        }

        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public double MyProperty3 { get; set; }
    }

    class Program
    {

        static void Print(object o)
        {
            Console.WriteLine($"Поток ID {Thread.CurrentThread.GetHashCode()}. Print начал работу");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{o} ");
                Thread.Sleep(100);
            }
            Console.WriteLine($"\nПоток ID {Thread.CurrentThread.GetHashCode()}. Print окончил работу");
        }

        static void PrintBag(object o)
        {
            Console.WriteLine($"Поток ID {Thread.CurrentThread.GetHashCode()}. PrintBag начал работу");

            Bag b = o as Bag;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{b.MyProperty1} {b.MyProperty2} {b.MyProperty3} ");
                Thread.Sleep(100);
            }
            Console.WriteLine($"\nПоток ID {Thread.CurrentThread.GetHashCode()}. PrintBag окончил работу");
        }

        static void Main(string[] args)
        {
			// Передача параметров метод отдельного потока


			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine($"Поток ID {Thread.CurrentThread.GetHashCode()}. Main начал работу");

            #region Print


            ParameterizedThreadStart pth1 = new ParameterizedThreadStart(Print);
            Thread thread1 = new Thread(pth1);
            thread1.Start("+ ");

            #endregion

            #region PrintBag

            ParameterizedThreadStart pth2 = new ParameterizedThreadStart(PrintBag);
            Thread thread2 = new Thread(pth2);
            thread2.Start(new Bag(2019, "Курс С#", 20.08));

            #endregion
 
            Console.WriteLine($"\nПоток ID {Thread.CurrentThread.GetHashCode()}. Main окончил работу");

        }
    }
}
