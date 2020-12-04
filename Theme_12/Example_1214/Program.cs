using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1214
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            List<Cat> cats = new List<Cat>();

            var r = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var c = new Cat($"Котик_{i}", $"Порода_{i}", r.Next(3, 12));
                cats.Add(c);
                Console.WriteLine(c);
            }

            Console.ReadKey();
            Console.WriteLine();

            cats.Sort();
            foreach (var e in cats) Console.WriteLine(e);
        }
    }
}

