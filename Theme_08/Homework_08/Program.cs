﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Домашнее задание 8
            /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
            /// В структуре присутствуют департаменты и сотрудники
            /// Каждый департамент может содержать не более 1_000_000 сотрудников.
            /// У каждого департамента есть поля: наименование, дата создания,
            /// количество сотрудников числящихся в нём 
            /// (можно добавить свои пожелания)
            /// 
            /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
            /// уникальный номер, размер оплаты труда, количество закрепленным за ним проектов.
            ///
            /// В данной информаиционной системе должна быть возможность 
            /// - импорта и экспорта всей информации в xml и json
            /// Добавление, удаление, редактирование сотрудников и департаментов
            /// 
            /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
            /// по нескольким полям, например возрасту и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            /// 
            /// 
            /// Упорядочивание по одному полю возраст
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            ///
            /// Упорядочивание по полям возраст и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            /// 
            /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            /// 
            #endregion

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Organization Apple = new Organization();
            Apple.GenerateDeptAndEmployees(5, 20);
            Apple.PrintDepts();
            Apple.PrintEmployees();
            Console.WriteLine("\nСортировка по номеру отдела\n");
            Apple.SortEmployeesByDep();
            Apple.PrintEmployees();
            Apple.SortByDepAgeSalary();
            Console.WriteLine("\nСортировка по возрасту\n");
            Apple.SortEmployeesByAge(0, Apple.Employees.Count - 5);
            Apple.PrintEmployees();
            Console.WriteLine("\nСортировка по зарплате\n");
            Apple.SortEmployeesBySalary(0, Apple.Employees.Count);
            Apple.PrintEmployees();
            Console.WriteLine("\nСортировка по деп, возраст и зарплате\n");
            Apple.SortByDepAgeSalary();
            Apple.PrintEmployees();

        }
    }
}
