using System;
using System.Text;
using System.Threading;

namespace Example_1642
{
	class Program
    {
        static Random random = new Random();

        static void ThreadTask(object o)
        {
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(random.Next(3000,5000));
        }

        static void GetThreadPoolInformation()
        {
            int workerThreadsAvailable, completionPortThreadsAvailable;
            ThreadPool.GetAvailableThreads(out workerThreadsAvailable, out completionPortThreadsAvailable);

            int workerThreadsMax, completionPortThreadsMax;
            ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);

            Console.WriteLine($"Доступно потоков в ThreadPool: {workerThreadsAvailable} из {workerThreadsMax}");
            Console.WriteLine($"Доступно потоков для ввода-вывода: {completionPortThreadsAvailable} из {completionPortThreadsMax}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            GetThreadPoolInformation();

            Console.ReadLine();

            for (int i = 0; i < 30; i++)
            {
                //if (i < 10)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadTask));
			}

                GetThreadPoolInformation();
				Thread.Sleep(250);

            Console.ReadLine();


        }
    }
}
