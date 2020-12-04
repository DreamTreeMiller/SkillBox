using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1637
{
    class Program
    {
        static void Log()
        {
            while (true)
            {
                Console.WriteLine($"Write log {DateTime.Now}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            // Фоновые потоки
            Thread th = new Thread(Log);
            th.Start();


            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Main");
                Thread.Sleep(100);
            }

            th.IsBackground = true;

        }
    }
}
