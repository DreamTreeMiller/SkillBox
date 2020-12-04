using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IComparable<
namespace Example_1334
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
    // interface IAnimal<in T>

    // T GetAnimal { get; set; }
    // void Method(T args);

    // Ошибка CS1961  Недопустимое отклонение: 
    // Параметр типа "T" должен быть ковариантно, допустимым на "IAnimal<T>.a()". 
    // "T" является контравариантный.Example_1334  

    #endregion

    interface IAnimal<in T>
        where T : Animal
    {
        T SetValue { set; }
        void SetValueMethod(T args);
    }

    class Storage<T> : IAnimal<T>
        where T: Animal
    {

        List<Animal> db;
        public Storage()
        {
            db = new List<Animal>();
        }

        public T SetValue { set => db.Add(value); }

        public void SetValueMethod(T args)
        {
            db.Add(args);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Контравариантность даёт возможность использовать более универсальный тип, чем заданный изначально

            // Ошибка CS0266  Не удается неявно преобразовать 
            // тип "Example_1334.Storage<Example_1334.Animal>" в "Example_1334.IAnimal<Example_1334.Bird>".
            // Существует явное преобразование(возможно, пропущено приведение типов).	
            IAnimal<Bird> concreteStorage = new Storage<Animal>();

            #region ToDo

            concreteStorage.SetValueMethod(new Bird("concreteBird"));

            #endregion


            object[] vs = new string[10];

            vs[1] = "строка";
            vs[0] = 1;
            vs[2] = 2.0;




        }
    }
}
