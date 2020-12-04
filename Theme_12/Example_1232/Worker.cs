using System;

namespace Example_1232
{
    /// <summary>
    /// Класс, описывающая рабочего
    /// </summary>
    class Worker
    {
        /// <summary>
        /// Статическое поле staticId
        /// </summary>
        private static int staticId;

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Worker()
        {
            staticId = 0;
        }

        /// <summary>
        /// Статический метод возвращающий следующие Id
        /// </summary>
        /// <returns></returns>
        private static int NextId()
        {
            staticId++;
            return staticId;
        }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public uint Salary { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Вывод данных о сотрунике
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id} Должность: {Position} Зарплата: {Salary} Имя: {FirstName} ";
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Position">Должность</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="FirstName">Имя</param>
        public Worker(string Position, uint Salary, string FirstName)
        {
            this.Id = Worker.NextId();
            this.Position = Position;
            this.Salary = Salary;
            this.FirstName = FirstName;
        }
    }
}
