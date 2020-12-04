using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1652
{
    class Program
    {
        static int count;

        static Random r = new Random();

        static void ChangeCount()
        {
            Interlocked.Increment(ref count);// count++;

            Thread.Sleep(r.Next(100, 500));

            Interlocked.Decrement(ref count);// count--;
            
        }


        static void ReadCount()
        {
            while (true)
            {
                Console.WriteLine($"count: {count}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {

            Thread threadReadCount = new Thread(ReadCount) { IsBackground = true };
            threadReadCount.Start();

            Thread[] threads = new Thread[1000];
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