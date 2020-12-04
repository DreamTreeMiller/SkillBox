using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Библиотека TPL
namespace Example_1661
{
    class Program
    {

        static void Method()
        {
            Console.WriteLine("Method начал работу.");

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Method: i = {i}");
            }

            Console.WriteLine("Method закончил работу.");
        }

        static void Main()
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Main начал работу.");

            var a = new Action(Method);

            var task = new Task(a);

            task.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(50);
            }

            Console.WriteLine("Main закончил работу.");
        }
    }
}