using System;

namespace Example_1221
{
    /// <summary>
    /// Класс, описывающая рабочего
    /// </summary>
    class Worker
    {
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
            return $"Должность: {Position} Зарплата: {Salary} Имя: {FirstName}";
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Position">Должность</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="FirstName">Имя</param>
        public Worker(string Position, uint Salary, string FirstName)
        {
            this.Position = Position;
            this.Salary = Salary;
            this.FirstName = FirstName;
        }
    }
}
