using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1333
{

    abstract class Animal
    {
        public string Name { get; private set; }
        public Animal(string Name) { this.Name = Name; }
    }

    class Bird : Animal
    {
        public Bird(string Name) : base(Name) { }
    }

    #region ToDo Важно
    // interface IAnimal<out T>

    // T GetAnimal { get; set; }
    // void Method(T args);
    // Ошибка CS1961  Недопустимое отклонение: 
    // Параметр типа "T" должен быть инвариантно, допустимым на "IAnimal<T>.GetAnimal". 
    // "T" является ковариантный.Example_1333    

    #endregion

    interface IAnimal<out T>
        where T : Animal
    {
        T GetValue { get; }
        T GetValueMethod(); 
    }

    class Kiwi : IAnimal<Bird>
    {
        public Bird GetValue { get { return new Bird("KiwiBirdP"); } }

        public Bird GetValueMethod() { return new Bird("KiwiBirdM"); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Kiwi concreteKiwi = new Kiwi();
            IAnimal<Bird> concreteBirdIAnimal = concreteKiwi;
            IAnimal<Animal> concreteAnimalIAnimal = concreteKiwi; // Нельзя т к типы инвариантны

            // Ковариантность даёт возможность использовать более конкретный тип, чем заданный изначально
            // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/out-generic-modifier>>
        }
    }
}
