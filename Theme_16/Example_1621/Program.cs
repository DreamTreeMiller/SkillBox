using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Многопоточность на основе потоков. Синхронизация доспупа к разделяемому ресурсу

namespace Example_1621
{
    class Program
    {
        static object o = new object(); // Объект синхронизации доступа к разделяемому ресурсу (объект блокировки)

        static void ThreadMethod(object text)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            lock (o) // Критическая секция - код, в котором происходит доспуп к разделяемому ресурсу (файл, консоль, бд и т д)
            //Monitor.Enter(o);
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Поток Id {id} => {text}"); // Разделяемый ресурс
                    Thread.Sleep(20);
                }
            }
            //Monitor.Exit(o);
        }

        static void Main(string[] args)
        {

            Thread thread1 = new Thread(ThreadMethod); thread1.Start("В кастрюле борщ "); // Повар 1
            Thread thread2 = new Thread(ThreadMethod); thread2.Start("В кастрюле каша "); // Повар 2
            Thread thread3 = new Thread(ThreadMethod); thread3.Start("В кастрюле салатик "); // Повар 2

            ThreadMethod("В кастрюле компот ");  // Повар 3

           

            Console.ReadLine();


        }
    }
}
