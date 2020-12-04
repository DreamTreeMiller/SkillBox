using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1623
{

    public class Arguments
    {
        public ConsoleColor Color { get; set; }
        public string Text { get; set; }
    }


    class Program
    {
        
        static object o = new object(); // Объект синхронизации доступа к разделяемому ресурсу (объект блокировки)

        static void ThreadMethod(object args)
        {
            Arguments a = args as Arguments;
            int id = Thread.CurrentThread.ManagedThreadId;

			lock (o) // Критическая секция
			{
				for (int i = 0; i < 5; i++)
                {
                    Console.ForegroundColor = a.Color;
                    Console.WriteLine($"Поток Id {id} => {a.Text}"); // Разделяемый ресурс
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Gray;

                }

			}

		}

        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;

            Thread thread1 = new Thread(ThreadMethod);
            thread1.Start(new Arguments { Text = "В кастрюле борщ ", Color = ConsoleColor.Blue }); // Повар 1

            Thread thread2 = new Thread(ThreadMethod);
            thread2.Start(new Arguments { Text = "В кастрюле каша ", Color = ConsoleColor.Red }); // Повар 2

            ThreadMethod(new Arguments { Text = "В кастрюле компот ", Color = ConsoleColor.Yellow });  // Повар 3

        }
    }
}
