using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1443
{

    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;

            var c = new Cat($"Барсик", $"Шотландский вислоухий", 3);
            Person robert = new Person("Роберт", c);

            c.ToMew();

            c.Owner = robert;

            robert.FeedTheCat();

        }
    }
}
