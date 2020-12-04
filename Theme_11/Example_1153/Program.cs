using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1153
{


    class A
    {
        public void M()
        {

        }
    }

    class B
    {

    }

    //class C : A, B
    //{

    //}

    interface IInterface1
    {

    }

    interface IInterface2
    {

    }

    class C : B, IInterface1, IInterface2
    {

    }

  

    class Program
    {
        static void Main(string[] args)
        {
            #region interface

            // Предназначены для описания общего поведения
            // Иногда используется для гарантии реализации некоторого поведения
            // Интерфейс - аналог полностью абстрактного класса, но позволяет множественное "наследование"

            // Интерфейсы могут содержать 
            //  Методы
            //  Свойства
            //  Индексаторы
            //  События

            #endregion

        }
    }
}
