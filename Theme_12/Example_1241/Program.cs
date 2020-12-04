using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1241
{
    class Program
    {
        static void Main(string[] args)
        {

             


            List<Worker> db = new List<Worker>()
            {
                 new Worker("Должность_1", 4, "Имя_1"),
                 new Worker("Должность_2", 2, "Имя_1"),
                 new Worker("Должность_3", 3, "Имя_2"),
                 new Worker("Должность_4", 10, "Имя_1"),
                 new Worker("Должность_5", 5, "Имя_3"),
                 new Worker("Должность_5", 11, "Имя_3"),
                 new Worker("Должность_5", 52, "Имя_3"),
                 new Worker("Должность_5", 15, "Имя_1"),
                 new Worker("Должность_5", 45, "Имя_1"),
                 new Worker("Должность_5", 5, "Имя_1"),
                 new Worker("Должность_5", 5, "Имя_1"),
                 new Worker("Должность_5", 5, "Имя_2"),
            };

            Console.WriteLine("db");

            foreach (var e in db)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();


            // db.Sort(); // IComparable
            db.Sort(new Worker.SortByName());

            Console.WriteLine("\nSortByName");


            foreach (var e in db)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("SortBySalary");

            db.Sort(new Worker.SortBySalary());
            foreach (var e in db)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}