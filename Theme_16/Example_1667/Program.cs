using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1667
{
    class Program
    {
        static int TaskResult()
        {
            Thread.Sleep(1000);

            return 2019 + 6;
        }

        static double Sum(object arg)
        {
            int o = (int)arg;
            double sum = 0;

            for (int i = 0; i <= o; i++) { sum += i; }

            Thread.Sleep(3000);
            return sum;
        }

        static void Main()
        {
            Console.WriteLine("Main запущен.");
            
            // Создание экземпляра первой задачи.
            Task<int> task1 = Task<int>.Factory.StartNew(TaskResult);
            Thread.Sleep(1500);

            Console.WriteLine($"Результат выполнения задачи TaskResult: {task1.Result}");

            // Создание экземпляра второй задачи.
            Task<double> task2 = Task<double>.Factory.StartNew(Sum, 10);
            Console.WriteLine($"Результат выполнения задачи Sum: {task2.Result}");

            task1.Dispose();
            task2.Dispose();

            Console.WriteLine("Main завершен.");

           
            Console.ReadKey();
        }
    }
}
