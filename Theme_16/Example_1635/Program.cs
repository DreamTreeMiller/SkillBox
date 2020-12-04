using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1635
{
    class Program
    {
        public static void ThreadMethod()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Начало id поток: {id}");

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    Console.Write("+ ");
                    Thread.Sleep(10);
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine($"\nКакой-то поток вызвал Thread.Abort(); {e.Message}");
                }
            }
            Console.WriteLine($"Конец id поток: {id}");
        }

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Thread thread = new Thread(ThreadMethod);

            thread.Start();
            Thread.Sleep(5000);

            thread.Abort();

            Console.WriteLine("\nКонец");


        }
    }
}
