using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1331
{

    class Animal { }        // Животное
    class Cat: Animal { }   // Кот
    class Dog: Animal { }   // Собака
    class Bird : Animal { } // Птица
    class Kiwi : Bird { }   // Птица Киви


    class Program
    {
        static void Main(string[] args)
        {

            Kiwi concreteKiwi = new Kiwi();

            Bird concreteBird = concreteKiwi;

            Animal concreteAnimal = concreteBird;
                   concreteAnimal = concreteKiwi;

            object abstractObject = concreteAnimal;
            abstractObject = concreteBird;
            abstractObject = concreteAnimal;

            
            List<Kiwi> listKiwi = new List<Kiwi>();

            List<Bird> listBird = new List<Bird>();

            List<Animal> listAnimal = new List<Animal>();

            // List<Animal> errorListAnimal = new List<Bird>();
            // List<Bird> errorListBird = new List<Kiwi>();

            // т к List<Animal> и List<Bird> никак не связаны в иерархии наследования

            // Инвариантность даёт возможность использовать только тот тип, 
            // который изначально задан  в обобщении


        }
    }
}
