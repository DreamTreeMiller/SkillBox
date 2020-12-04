using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1622
{
    class Program
    {
        static object o = new object(); // Объект синхронизации доступа к разделяемому ресурсу (объект блокировки)

        static void ThreadMethod(object text)
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            Monitor.Enter(o); // Критическая секция

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Поток Id {id} => {text}"); // Разделяемый ресурс
                Thread.Sleep(20);
            }

            Monitor.Exit(o);

        }

        static void Main(string[] args)
        {

            Thread thread1 = new Thread(ThreadMethod); thread1.Start("В кастрюле борщ "); // Повар 1
            Thread thread2 = new Thread(ThreadMethod); thread2.Start("В кастрюле каша "); // Повар 2

            ThreadMethod("В кастрюле компот ");  // Повар 3
 

            Console.ReadLine();
        }
    }
}
