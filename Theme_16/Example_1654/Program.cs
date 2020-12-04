using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1654
{
    class Program
    {
        static long sum = 0;
        static long valueA = 10;

        static Random r = new Random();
        private static object o = new object();

        static void ChangeCount()
        {

			//Monitor.Enter(o); sum += valueA; Monitor.Exit(o);
			//Thread.Sleep(r.Next(100, 500));
			//Monitor.Enter(o); sum -= valueA; Monitor.Exit(o);

			lock (o) { sum += valueA; }
			Thread.Sleep(r.Next(100, 500));
			lock (o) { sum -= valueA; }

			//Interlocked.Add(ref sum, alueA);
			//Interlocked.Add(ref sum, -valueA);
		}

        static void ReadCount()
        {
            while (true)
            {
                Console.WriteLine($"count: {sum}");
                //var value = Interlocked.Read(ref sum); Console.WriteLine($"count: {value}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            // Ролик 5. Атомарные операции
            Thread threadReadCount = new Thread(ReadCount) { IsBackground = true };
            threadReadCount.Start();
            //Thread.Sleep(2000);
            Thread[] threads = new Thread[500];
            Console.WriteLine($"threads.Length: {threads.Length}");

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ChangeCount);
                threads[i].Start();

            }

            Console.ReadLine();
        }
    }
}
