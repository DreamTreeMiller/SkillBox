using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1668
{
    class Program
    {
        static void Method(object cancel)
        {
            var token = (CancellationToken)cancel;

            token.ThrowIfCancellationRequested();

            Console.WriteLine("Method() запущен.");

            for (int i = 0; i < 50; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Получен запрос на отмену задачи.");
                    token.ThrowIfCancellationRequested();
                }

                Thread.Sleep(200);
                Console.WriteLine($"В методе Method(), счетчик равен: {i} +");
            }
            Console.WriteLine("Method() завершен.");
        }

        static void Main()
        {
            Console.WriteLine("Main запущен.");

            var cancelTokSrc = new CancellationTokenSource(); // источник признаков отмены

            Task task = Task.Factory.StartNew(Method, cancelTokSrc.Token, cancelTokSrc.Token);

            Thread.Sleep(3000);

            try
            {
                //cancelTokSrc.Cancel();

                task.Wait();
            }
            catch (AggregateException e)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nЗадача task отменена.\n");

                Console.WriteLine("- " + e.InnerException.Message); 
            }
            finally
            {
                task.Dispose();
                cancelTokSrc.Dispose();
            }

            Console.WriteLine("Main завершен.");

             
            Console.ReadKey();
        }
    }
}
