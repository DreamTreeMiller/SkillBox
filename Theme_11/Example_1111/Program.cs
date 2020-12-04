using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1111
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ролик 1. Понятие класса, объекта, экземпляра класса

            /// Создание котиков
            Cat cat1 = new Cat("Басик", "Русская голубая кошка");
            Cat cat2 = new Cat("Мурзик", "Мейн-кун");
            Cat cat3 = new Cat("Плюмгильда", "Манчкин");

            /// Создание домов
            House house1 = new House(18, 182, "г. Смоленск, ул. Ленина, д. 1");
            House house2 = new House(18, 182, "п. Запрудня, ул. Пролетарский проспект, д. 2");

            /// Создание роботов
            Robot robot = new Robot("С-3PO", "Звёздные воины");


        }
    }
}
