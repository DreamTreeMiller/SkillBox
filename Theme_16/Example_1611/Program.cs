using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1611
{
    class Program
    {
        
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Начало... ");

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"+ ");
                Thread.Sleep(20);
            }

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"- ");
                Thread.Sleep(20);
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nОкончание... ");

        }
    }
}
