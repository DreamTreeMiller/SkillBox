using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1653
{
    class Program
    {
        static long sum;
        static long valueA = 10;

        static Random r = new Random();

        static void ChangeCount()
        {
            sum += valueA; 
            //Interlocked.Add(ref sum, valueA);

            Thread.Sleep(r.Next(100, 500));

            sum -= valueA; 
            //Interlocked.Add(ref sum, -valueA);
            

        }


        static void ReadCount()
        {
            while (true)
            {
                //Console.WriteLine($"count: {sum}");
                var value = Interlocked.Read(ref sum);  Console.WriteLine($"count: {value}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            // Ролик 5. Атомарные операции
            Thread threadReadCount = new Thread(ReadCount) { IsBackground = true };
            threadReadCount.Start();

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
