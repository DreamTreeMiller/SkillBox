using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_1541_ClassLibrary;

namespace Example_1541
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MyMath.Sum(12, 34);

            Console.WriteLine($"r = {r}");

            Console.ReadKey();
        }
    }
}
