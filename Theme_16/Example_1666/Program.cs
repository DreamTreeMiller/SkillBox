using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1666
{
    class Program
    {
        static void Method()
        {
            Console.WriteLine($"Method() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine($"Method() # { Task.CurrentId } i = {i} +");
            }

            Console.WriteLine($"Method() CurrentId {Task.CurrentId} окончен.");
        }


        static void NextMethod(Task t)
        {
            Console.WriteLine($"NextMethod() CurrentId {Task.CurrentId} запущен.");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);

                Console.WriteLine($"NextMethod() # { Task.CurrentId } i = {i} - ");
            }

            Console.WriteLine($"NextMethod() CurrentId {Task.CurrentId} окончен.");
        }

        static void Main()
		{
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Main запущен.");

            var t1 = new Task(Method);
            var t2 = t1.ContinueWith(NextMethod);


            t1.Start();
            t2.Wait();

			//Метод Main() остается активным до завершения задачи Method(). 
            for (int i = 0; i < 50; i++)
			{
				Console.Write("- ");
				Thread.Sleep(50);
			}
			Console.WriteLine();


			Console.WriteLine("Main окончен");
            Console.WriteLine($"\nId основного потока равен null : {Task.CurrentId == null}.");
            t1.Dispose();
            t2.Dispose();

        }
    }
}
