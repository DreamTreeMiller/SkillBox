using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1215
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var data1 = new Repository(5);

            data1.Print("data 1");

            Repository data2 = data1;

            data2.Print("data 2");

            Console.WriteLine("\n === \n");


            data1.ChangeFirstName(0, "Новое имя");

            data1.Print("data 1");

            data2.Print("data 2");

            Console.ReadKey();
        }
    }
}
