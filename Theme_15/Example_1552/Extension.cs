using System;
using System.Collections.Generic;

namespace Example_1552
{
    /// <summary>
    /// Методы расширения
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Вывод числа в консоль
        /// </summary>
        /// <param name="item">Число</param>
        public static void Print(this double item)
        {
            Console.WriteLine(item);
        }

        /// <summary>
        /// Возведение в степень
        /// </summary>
        /// <param name="Base">Основание степени</param>
        /// <param name="Indicator">Показатель степени</param>
        /// <returns>Результат</returns>
        public static double Pow(this int Base, int Indicator)
        {
            return Math.Pow(Base, Indicator);
        }

        /// <summary>
        /// Добавление в коллекцию элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <param name="col">Коллекция</param>
        public static void AddToList(this int item, List<int> col)
        {
            col.Add(item);
        }


    }
}
