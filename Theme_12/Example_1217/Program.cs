using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1217
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var rep = new Repository(10);
            rep.Print("Вывод");

            foreach (var item in rep.Workers)
            {
                Console.WriteLine(item);
            }

        }
    }
}
