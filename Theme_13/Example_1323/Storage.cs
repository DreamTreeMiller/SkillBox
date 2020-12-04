using System.Collections.Generic;

namespace Example_1323
{
    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Наследники класса А</typeparam>
    class Storage<T>
        where T : A
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public int GetLastProperty()
        {
            return this.DataBase.Count > 0 ? this.DataBase[this.DataBase.Count - 1].Property : -1;
        }

        /// <summary>
        /// Добавление значения в базу данных данных
        /// </summary>
        /// <param name="Item">Добавляемый элемент</param>
        public void Add(T Item)
        {
            DataBase.Add(Item);
        }

    }
}
