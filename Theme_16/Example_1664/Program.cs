using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1664
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine($"Method() # { Task.CurrentId } i = {i} +");
            }

            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }

        static void Method2()
        {
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine($"Method() # { Task.CurrentId } i = {i} -");
            }

            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }

        static void Main()
		{   
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Main запущен.");

            var t1 = new Task(Method1);
            var t2 = new Task(Method2);

            // Выполнение задач.
            t1.Start();
            t2.Start();

            Console.WriteLine($"Идентификатор задачи t1: {t1.Id}");
            Console.WriteLine($"Идентификатор задачи t2: {t2.Id}");

            // Метод Main() остается активным до завершения задачи Method(). 
            for (int i = 0; i < 10; i++)
            {
                Console.Write("- ");
                Thread.Sleep(50);
            }

            Task.WaitAll(t1, t2);
            //Task.WaitAny(t1, t2);

            Console.WriteLine("Main окончен");
            Console.WriteLine($"\nId основного потока равен null : {Task.CurrentId == null}.");


        }
    }
}
