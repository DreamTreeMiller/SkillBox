using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1616
{
    class Program
    {
        static void Log()
        {
            while (true)
            {
                Console.WriteLine($"Write log {DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(100);
            }   
        }

        static void Main(string[] args)
        {
            // Фоновые потоки
            Thread t = new Thread(Log);
            t.Start();
            t.IsBackground = true;


            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"         Main");
                Thread.Sleep(100);
            }

           
            
        }
    }
}
