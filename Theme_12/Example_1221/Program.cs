using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1221
{
    class Program
    {
        static void Main(string[] args)
        {

            // Структуры и введение в ООП
            // Ролик 3. Описание членов структуры: конструкторы, свойства, индексаторы

            DataProvider db = new DataProvider(
                 new Worker("Должность_1", 10000, "Имя_444"),
                 new Worker("Должность_2", 10000, "Имя_2"),
                 new Worker("Должность_3", 10000, "Имя_3"),
                 new Worker("Должность_4", 10000, "Имя_4"),
                 new Worker("Должность_5", 10000, "Имя_5")
                 );


            Console.WriteLine(db[0]);
            
            Console.WriteLine(db["Имя_3"]);
            Console.WriteLine(db["Имя_7"]==null);
            if(db["Имя_7"]!=null) Console.WriteLine(db["Имя_7"].FirstName);
            Console.WriteLine(db["Имя_3", "Должность_3"]);





            Console.ReadKey();
        }
    }
}
