using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1232
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Worker> db = new List<Worker>()
            {
                 new Worker("Должность_1", 10000, "Имя_1"),
                 new Worker("Должность_2", 10000, "Имя_2"),
                 new Worker("Должность_3", 10000, "Имя_3"),
                 new Worker("Должность_4", 10000, "Имя_4"),
                 new Worker("Должность_5", 10000, "Имя_5"),
            };

            foreach (var e in db)
            {
                Console.WriteLine(e);
            }
        }
    }
}
