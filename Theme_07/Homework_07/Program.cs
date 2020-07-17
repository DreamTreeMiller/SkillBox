using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    #region Домашнее задание 7
    // Разработать ежедневник.
    // В ежедневнике реализовать возможность 
    // - создания
    // - удаления
    // - реактирования 
    // записей
    // 
    // В отдельной записи должно быть не менее пяти полей
    // 
    // Реализовать возможность 
    // - Загрузки даннах из файла
    // - Выгрузки даннах в файл
    // - Добавления данных в текущий ежедневник из выбранного файла
    // - Импорт записей по выбранному диапазону дат
    // - Упорядочивания записей ежедневника по выбранному полю
    #endregion Домашнее задание 7

    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            short rYear;            
            sbyte rMonth;            // 1 - 12
            sbyte rDay;              // 1 - 31
            sbyte rHour;
            sbyte rMin;
            sbyte rSec;
            TypeOfNote rTypeOfNote;       // 0, 1, 2
            string rTitle = "Title_";
            string rText  = "Text";
            bool rFlag;             // Флажок для типов записи событие (1) или дело (2)
            bool rStar;
            SimpleDateTime rDT;
            OrganizerClass myOrganizer = new OrganizerClass();

            for (int i = 0; i < 365; i++)
			{
                rYear =  (short)r.Next(1998, 2003);
                rMonth = (sbyte)r.Next(1, 13);
                if (rYear == 2000 & rMonth == 2) rDay = (sbyte)r.Next(1, 30); // високосный февраль
                else rDay = (sbyte)r.Next(1, YearClass.monthsLength[rMonth] + 1);
                rHour = (sbyte)r.Next(1, 24);
                rMin  = (sbyte)r.Next(1, 60);
                rSec  = (sbyte)r.Next(1, 60);
                rTypeOfNote = (TypeOfNote)r.Next(0, 3);
                rTitle = $"Title_{rYear}{rMonth}{rDay}_{rHour}:{rMin}:{rSec}";
                rText = $"This is the day {rDay} of month {rMonth} of the year {rYear}." +
                        $" Time now is {rHour} hours {rMin} minutes {rSec} seconds. Aju!";
                rFlag = r.Next(0, 2) == 1 ? true : false;
                rStar = r.Next(0, 2) == 1 ? true : false;

                rDT = new SimpleDateTime(rYear, rMonth, rDay, rHour, rMin);
                myOrganizer.AddNote(rDT, rTitle, rText, rTypeOfNote, rFlag, rStar);
            }

            foreach (var yyyy in myOrganizer.Organizer)         // Берём по порядку все годы из ежедневника
            // myOrganizer.Organizer это SortedList<short,YearClass>
            // yyyy это KeyValuePair < short, YearClass > - значит из yyyy надо взять год
            // год - это yyyy.Value
            // а из года все месяцы
                foreach (DayClass[] mm in yyyy.Value.year)      // Берём по порядку все месяцы из года
                // yyyy.Value.year - это DayClass[][]
                // mm - это месяц, т.е. yyyy.Value.year[]
                {
                    if (mm == null) continue;   // т.к. мы нумеруем месяцы с 1, то 0-й элемент равен null
                                                // или если месяц не инициализирован, т.е. в нём нет ни одной записи
                                                // надо его пропустить

                    foreach (DayClass dd in mm)                 // Берём по порядку все дни
                    // dd - это день!
                    {
                        if (dd == null) continue;       // т.к. мы нумеруем дни с 1, то 0-й элемент равен null
                                                        // или если день не инициализирован, т.е. в нём нет ни одной записи
                                                        // надо его пропустить
                        foreach (var record in dd.Day)
                        {
                            string printDT = record.Value.DisplayDT.ToStringWithID();
                            Console.WriteLine($"Date: {printDT}");
                            Console.WriteLine($"{record.Value.noteStack.Peek().Title}");
                            Console.WriteLine($"{record.Value.noteStack.Peek().Text}");
                            Console.WriteLine();
                        }
                    }
                }
            Console.WriteLine($"Total records in the organizer: {myOrganizer.Count}");
            Console.WriteLine($"Last ID generated: {myOrganizer.IDcounter}");

        }


    }
}
