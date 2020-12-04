using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1669
{
    class Program
    {
        static int[] arr;
        static readonly object o = new object();
        static int sum;
        static void Fill(int i)
        {
            arr[i] = i / 1000;
            lock (o) { sum += arr[i]; }
        }

        static void Main(string[] args)
        {
            arr = new int[1_000_000];
            Stopwatch s = new Stopwatch();
            int sum1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            s.Reset();
            s.Start();

            for (int i = 0; i < arr.Length; i++) sum1 += arr[i] / 1000;

            s.Stop();

            Console.WriteLine($"Sync evaluation elapsed = {s.ElapsedMilliseconds} ms.  Sum = {sum1}");

			Console.WriteLine(); Console.WriteLine("press Enter to continue ...");
            Console.ReadLine();

            s.Reset(); s.Start();

            Parallel.For(0, arr.Length, Fill);

            s.Stop();

            Console.WriteLine($"Parallel.For evaluation elapsed = {s.ElapsedMilliseconds} ms.  Sum = {sum}");

        }
    }
}
