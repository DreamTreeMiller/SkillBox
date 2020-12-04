using System;
using System.Collections;
using System.Collections.Generic;

namespace Example_1242
{


    enum SortedCriterion
    {
        FirstName,
        Salary
    }

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
            return $"Id: {Id,4} Должность: {Position,15} Зарплата: {Salary,5} Имя: {FirstName,15} ";
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Position">Должность</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="FirstName">Имя</param>
        public Worker(string Position, uint Salary, string FirstName)
        {
            this.Id = NextId();
            this.Position = Position;
            this.Salary = Salary;
            this.FirstName = FirstName;
        }

        private class SortBySalary : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker Y = (Worker)x;
                Worker X = (Worker)y;

                if (X.Salary == Y.Salary) return 0;
                else if (X.Salary > Y.Salary) return 0;
                else return -1;
            }

        }

        private class SortByName : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                return String.Compare(X.FirstName, Y.FirstName);
            }
        }


        public static IComparer<Worker> SortBy(SortedCriterion Criterion)
        {
            if (Criterion == SortedCriterion.Salary) return new SortBySalary();
            else return new SortByName();

        }

    }
}
