using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1638_Priority
{
    class ThreadWrapper
    {
        static bool endCalculations;
        int priority;

        static ThreadWrapper()
        {
            endCalculations = false;
        }

        public Thread t;
        private int args;

        public ThreadWrapper(int priority, int arg)
        {
            t = new Thread(Calc);
            args = arg;
            this.priority = priority;
        }

        public ThreadPriority Priority { set { t.Priority = value; } }


        private void Calc()
        {
            Stopwatch stopwatch = new Stopwatch();
			Console.WriteLine($"Вызов задачи {priority} ");
            stopwatch.Start();
            while (!endCalculations && this.args != 0)
            {
                args--;
				//switch (priority)
				//{
				//	case 5:
				//		Console.ForegroundColor = ConsoleColor.Yellow;
				//		break;
				//	case 3:
				//		Console.ForegroundColor = ConsoleColor.Green;
				//		break;
				//	case 1:
				//		Console.ForegroundColor = ConsoleColor.Red;
				//		break;
				//}
				//Console.Write($"  {priority}");
			}

            endCalculations = true;
            stopwatch.Stop();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine();
			//Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершён. Приоритет {t.Priority}. Args = {args:N0}");
			Console.WriteLine($" {priority}-й завершён" 
                            + $" {t.Priority, 11}" 
                            + $" Args {args,11:N0}"
                            + $" Elpsd {stopwatch.ElapsedTicks,10:N0} ticks"
                            + $" Elpsd {stopwatch.ElapsedMilliseconds} ms"
                            );
        }

        public void Start()
        {
            t.Start();
        }
    }
}
