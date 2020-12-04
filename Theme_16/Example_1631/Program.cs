using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Синхронизация потоков

namespace Example_1631
{
    class Program
    {

        static void Method()
        {
            var th = Thread.CurrentThread;

            th.Name = "MethodThread";

            Console.WriteLine($"Поток: {th.Name}, ID: {th.GetHashCode()}");

            for (int i = 0; i < 100; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nПоток: {th.Name}, ID: {th.GetHashCode()}. Конец работы");
        }

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            var mainThread = Thread.CurrentThread;

            mainThread.Name = "CurrentThread";

            Console.WriteLine($"Поток: {mainThread.Name}, ID: {mainThread.GetHashCode()}");


            Thread secondThread = new Thread(Method);
            secondThread.Start();
			secondThread.Join(); // текущий поток, т.е. в котором выполнилось secondThread.Join()
                                // перешел в состояние сна( ожидания)
                                // и ждёт завершения выполнения потока secondThread 

            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nПоток: {mainThread.Name}, ID: {mainThread.GetHashCode()}. Конец работы");


        }
    }
}
