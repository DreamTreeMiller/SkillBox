using System;
using System.Collections.Generic;

namespace Example_1324
{
    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IInterface1</typeparam>
    class Storage1<T>
         where T: IInterface1
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage1()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public int GetLastProperty()
        {
            return this.DataBase.Count > 0 ? this.DataBase[this.DataBase.Count - 1].Property1 : -1;
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

    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IInterface2</typeparam>
    class Storage2<T>
         where T : IInterface2
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage2()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public int GetLastProperty()
        {
            return this.DataBase.Count > 0 ? this.DataBase[this.DataBase.Count - 1].Property2 : -1;
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

    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IInterface3<T></U></typeparam>
    class Storage3<T>
         where T : IInterface3<string>
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage3()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public string GetLastProperty()
        {
            return this.DataBase.Count > 0 ? this.DataBase[this.DataBase.Count - 1].Property3 : String.Empty;
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

    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IInterface3<T></U></typeparam>
    class Storage4<T>
         where T : IInterface3<int>
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage4()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public int GetLastProperty()
        {
            return this.DataBase.Count > 0 ? this.DataBase[this.DataBase.Count - 1].Property3 : -1;
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

    /// <summary>
    /// Хранилище
    /// </summary>
    /// <typeparam name="T">Тип, реализующий IInterface3<T></U></typeparam>
    class Storage5<T>
         where T : IInterface1, IInterface2
    {
        /// <summary>
        /// База данных
        /// </summary>
        public List<T> DataBase { get; set; }

        /// <summary>
        /// Конструктор по умолчаию
        /// </summary>
        public Storage5()
        {
            DataBase = new List<T>();
        }

        /// <summary>
        /// Получение значения свойства Property последнего добавленного элемента
        /// </summary>
        /// <returns>Значения свойства Property</returns>
        public int GetLastProperty()
        {

            return this.DataBase.Count > 0 ?
                this.DataBase[this.DataBase.Count - 1].Property1 + this.DataBase[this.DataBase.Count - 1].Property2
                : -1;
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
