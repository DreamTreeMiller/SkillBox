using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1218
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new Repository(10);
            rep.Print("Вывод");

            foreach (var item in rep)
            {
                Console.WriteLine(item);
            }
        }
    }
}
