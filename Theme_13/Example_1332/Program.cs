using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1332
{

    class Program
    {
        static void Main(string[] args)
        {
            #region 

            List<Kiwi> listKiwi = new List<Kiwi>() { new Kiwi() };
            List<Bird> listBird = new List<Bird>() { new Bird() };
            List<Animal> listAnimal = new List<Animal> { new Animal() };

            // Ковариантность даёт возможность использовать более конкретный тип, чем заданный изначально

            IEnumerable<Animal> enumerableAnimal = listKiwi;

            listAnimal = enumerableAnimal.ToList();

            IEnumerable<object> enumerableObject = listKiwi;

            List<object> listObject = enumerableObject.ToList();

            foreach (var item in listObject) Console.WriteLine(item.GetType());

            Console.ReadKey();
            Console.Clear();

            #endregion
        }
    }
}
