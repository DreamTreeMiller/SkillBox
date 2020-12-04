using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1633
{

    class Program
    {
        
        public static void ThreadMethod()
        {
            if (Provider.Data < 10)
            {
                Provider.Data++;
                int id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Начало id поток: {id}");


                Thread th = new Thread(ThreadMethod);
                th.Start();
                th.Join();
                Thread.Sleep(100);
                Console.WriteLine($"Конец id поток: {id}");
            }
        }

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            ThreadMethod();
        }
    }
}
