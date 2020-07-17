using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Department
    {
        private ushort    depID;
        public ushort     DepID                           // От 1 до 9999
        { 
            get { return this.depID; } 
            set
			{
                if (value <= 0) depID = 1;
                if (value > 9999) depID = 9999;
                this.depID = value;
			}
        }

        private string depName;
        public string   DepName                         // Сделаем стандартным Отдел_хххх - 
        {                                               // хххх - цифры от 0001 до 9999
            get { return "Отдел_" + $"{depID:0000}"; } 
        }
        public DateTime OpeningDate { get; set; }
        public uint     NumOfEmpl   { get; set; }

        public string   Projects    { get; set; }
        public Department() { }         // Надо явно объявлять для сериализации в XML
        public Department(ushort depID, uint numOfEmpl)
		{
            DepID = depID;
            NumOfEmpl = numOfEmpl;
            OpeningDate = DateTime.Now;
            Projects = "No projcets yet";
		}

        /// Предикат проверки номер департамента для List.Find
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=netcore-3.1#System_Collections_Generic_List_1_Find_System_Predicate__0__
	    /// Ну и другие тоже надо писать
    }

    public class Employee
	{
        public int      ID          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public sbyte    Age         { get; set; }
        public string   Dept        { get; set; }
        public int      Salary      { get; set; }
        public byte     NumOfProj   { get; set; }
        public Employee() { }        // Надо явно объявлять для сериализации в XML
    }

    public class Organization
	{
        public List<Department> Departments;
        public List<Employee> Employees;
        public int numberOfDepts;
        public int totalEmployees;

        public Organization()
		{
            Departments = new List<Department>();
            numberOfDepts = 0;
            Employees = new List<Employee>();
            totalEmployees = 0;
		}

        /// <summary>
        /// Добавляет новый отдел с названием Отдел_ХХХХ. 
        /// </summary>
        /// <param name="depNum">уникальный номер отдела</param>
        /// <param name="numOfEmpl">количество сотрудников в отделе</param>
        /// <returns>0  - если отдел успешно открыт</returns>
        /// <returns>-1 - если номер отдела меньше или равен 0, или больше 9999</returns>
        /// <returns>-2 - если отдел с таким номером уже существует</returns>
        public int OpenDept(ushort depNum, uint numOfEmpl)
        {
            if (depNum <= 0 || depNum > 9_999) return -1;  // Номер отдела от 1 до 9_999
            if (DeptNumExists(depNum)) return -2;            // Департамент с таким номером уже существует
            Department newDep = new Department(depNum, numOfEmpl);
            Departments.Add(newDep);
            return 0;

        }

        /// <summary>
        /// Проеверяет, существует ли отдел с таким номером
        /// </summary>
        /// <param name="depNum">Номер отдела</param>
        /// <returns>true - существует</returns>
        /// <returns>false - нет</returns>
        public bool DeptNumExists(uint depNum)
		{
            return true;
		}

        public bool CloseDept(ushort depID)
		{
            return true;
		}
    }
    class Program
    {
        static void Main(string[] args)
        {
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



            List<Employee> allWorkers = new List<Employee>();

            allWorkers.Sort()




        }
    }
}
