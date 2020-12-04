using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1341
{

    class Cat
    {
        public string Name { get; set; }
        public static explicit operator Cat(Animal cat)
        {
            return new Cat { Name = cat.Breed };
        }
    }

    class Animal
    {
        public string Breed { get; set; }
        public static implicit operator Animal(Cat cat)
        {
            return new Animal { Breed = cat.Name };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Cat cat = new Cat { Name = "Барсик" };
            Console.WriteLine($"cat.Name = {cat.Name}");

            #region  implicit operator

            Animal animal = cat;
            Console.WriteLine($"animal.Breed = {animal.Breed}");

            #endregion

            #region explicit operator

            cat = (Cat)animal;
            Console.WriteLine($"cat.Name = {cat.Name}");

            #endregion

            // https://marketplace.visualstudio.com/items?itemName=vs-publisher-306627.NETReflectorVisualStudioExtension
        }
    }
}
