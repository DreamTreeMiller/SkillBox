using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1651
{
    class Program
    {
        static int count;

        static Random r = new Random();

        static void ChangeCount()
        {
            count++;

            Thread.Sleep(r.Next(100, 500));

            count--;
        }


        static void ReadCount()
        {
            while (true)
            {
                Console.WriteLine($"count: {count}");
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            // Ролик 5. Атомарные операции
            Thread tReadCount = new Thread(ReadCount) { IsBackground = true };
            tReadCount.Start();

            count = 0;

            Thread[] threads = new Thread[1500];
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
