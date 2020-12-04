using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1665
{
    class Program
    {
        static void Method()
        {
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine($"Method() # { Task.CurrentId } i = {i}");
            }

            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }

        static void Main()
		{ 
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Main запущен.");

            var t1 = Task.Factory.StartNew(Method);
            var t2 = Task.Factory.StartNew(Method);

            // Выполнение задач.
           
            Console.WriteLine($"Идентификатор задачи t1: {t1.Id}");
            Console.WriteLine($"Идентификатор задачи t2: {t2.Id}");

            // Метод Main() остается активным до завершения задачи Method(). 
            for (int i = 0; i < 3; i++)
            {
                Console.Write("- ");
                Thread.Sleep(50);
            }

			Task.WaitAny(t1, t2);
			//Task.WaitAll(t1, t2);

			Console.WriteLine("Main окончен");
            Console.WriteLine($"\nId основного потока равен null : {Task.CurrentId == null}.");


        }
    }
}
