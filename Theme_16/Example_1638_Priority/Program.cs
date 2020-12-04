using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1638_Priority
{
    class Program
    {


        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
			int arg = 1_000_000_000;

			ThreadWrapper[] threads = new ThreadWrapper[]
            {
                new ThreadWrapper(1, arg) { Priority = ThreadPriority.Lowest},
                new ThreadWrapper(2, arg) { Priority = ThreadPriority.Normal },
                new ThreadWrapper(3, arg) { Priority = ThreadPriority.Lowest }
            };

			//foreach (var e in threads) e.Start();
			threads[0].Start(); // Highest
			threads[1].Start(); // Normal
			threads[2].Start(); // Lowest

			foreach (var e in threads) e.t.Join();

			Console.WriteLine();
			int ashow = arg;

			Stopwatch s = new Stopwatch();

			s.Start();
			while (arg != 0)
			{
				arg--;
			}

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
			s.Stop();
			Console.WriteLine($"\nWhile {ashow:N0} cycle took {s.ElapsedTicks:N0} ticks"
							+ $" Elapsed {s.ElapsedMilliseconds} ms "
							);
			
		}
	}
}