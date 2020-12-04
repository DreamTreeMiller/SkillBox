using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1231
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Worker> db = new List<Worker>()
            {
                 new Worker("Должность_1", 10000, "Имя_1", 1),
                 new Worker("Должность_2", 10000, "Имя_2", 1),
                 new Worker("Должность_3", 10000, "Имя_3", 1),
                 new Worker("Должность_4", 10000, "Имя_4", 4),
                 new Worker("Должность_5", 10000, "Имя_5", 5)
            };

            foreach (var e in db)
            {
                Console.WriteLine(e);
            }
        }
    }
}
