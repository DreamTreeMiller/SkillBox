using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1242
{
    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
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
            db.Sort(Worker.SortBy(SortedCriterion.Salary));

            Console.WriteLine("SortBySalary");


            foreach (var e in db)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nSortByName");
            db.Sort(Worker.SortBy(SortedCriterion.FirstName));
            foreach (var e in db)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}