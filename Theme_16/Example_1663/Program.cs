using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1663
{
    class Program
    {
        static void Method()
        {
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(20);

                Console.WriteLine($"Method() # { Task.CurrentId } i = {i}");
            }

            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }

        static void Main()
        {
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Main запущен.");

            var t1 = new Task(Method);
            var t2 = new Task(Method);

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

			t1.Wait();
			t2.Wait();

			Console.WriteLine("Main окончен");
            Console.WriteLine($"\nId основного потока равен null : {Task.CurrentId == null}.");


        }
    }
}
