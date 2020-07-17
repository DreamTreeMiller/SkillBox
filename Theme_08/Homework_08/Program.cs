using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Department
    {
        private int    depID;
        public int     DepID                           // От 1 до 9999
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
        public int     NumOfEmpl   { get; set; }

        public string   Projects    { get; set; }
        public Department() { }         // Надо явно объявлять для сериализации в XML
  
        /// <summary>
        /// Конструктор. Создает отдел. Дата отдела - текущая. Поле проекты - No projects yet.
        /// </summary>
        /// <param name="depID">Номер отдела</param>
        /// <param name="numOfEmpl">Количество сотрудников</param>
        public Department(int depID, int numOfEmpl)
		{
            DepID = depID;
            NumOfEmpl = numOfEmpl;
            OpeningDate = DateTime.Now;
            Projects = "No projects yet";
		}

        /// Предикат проверки номер департамента для List.Find
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=netcore-3.1#System_Collections_Generic_List_1_Find_System_Predicate__0__
	    /// Ну и другие тоже надо писать
        
        public override string ToString()
		{
            return $"{DepName,12}" +
                   $", создан {OpeningDate,12:dd.MM.yyyy}" +
                   $", кол-во сотрудников: {NumOfEmpl,8}" +
                   $", {Projects}";
		}
    }

    public class Employee
	{
        public int      ID          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public int    Age         { get; set; }
        private int  depID;
        public string   DepName     { get { return "Отдел_" + $"{depID:0000}"; } }
        public int      Salary      { get; set; }
        public int     NumOfProj   { get; set; }
        public Employee() { }        // Надо явно объявлять для сериализации в XML
        public Employee(int id, string firstN, string lastN, int age, int depNum, int salary, int nofpr)
		{
            ID          = id;
            FirstName   = firstN;
            LastName    = lastN;
            Age         = age;
            depID       = depNum;
            Salary      = salary;
            NumOfProj   = nofpr;
		}
        public override string ToString()
		{
            return $"{ID,8}" +
                   $"{FirstName,10}" +
                   $"{LastName,16}" +
                   $"{Age,12}" +
                   $"{DepName,16}" +
                   $"{Salary,10:###,###}" +
                   $"{NumOfProj,8}";
        }
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
        public int OpenDept(int depNum, int numOfEmpl)
        {
            if (depNum <= 0 || depNum > 9_999) return -1;  // Номер отдела от 1 до 9_999
            if (DeptNumExists(depNum)) return -2;            // Департамент с таким номером уже существует
            Department newDep = new Department(depNum, numOfEmpl);
            Departments.Add(newDep);
            numberOfDepts++;
            return 0;

        }

        /// <summary>
        /// Проеверяет, существует ли отдел с таким номером
        /// </summary>
        /// <param name="depNum">Номер отдела</param>
        /// <returns>true - существует</returns>
        /// <returns>false - нет</returns>
        private bool DeptNumExists(int depNum)
		{
            return true;
		}

        public bool CloseDept(int depID)
		{
            numberOfDepts--;
            return true;
		}

        /// <summary>
        /// Создает заданное количество отделов, в каждом не более maxEmp сотрудников
        /// </summary>
        /// <param name="maxDep">Количество отделов для создания</param>
        /// <param name="maxEmp">Максимальное кол-во сотрудников в одном отделе</param>
        /// <returns>Результат записывается в коллекции Departments и Employees</returns>
        public void GenerateDeptAndEmployees(int maxDep, int maxEmp)
		{
            Random r = new Random();
            int nEmp;
            totalEmployees = 1;
            numberOfDepts = maxDep;
            for (int i=1; i <= maxDep; i++)
			{
                nEmp = r.Next(1, maxEmp + 1);
                Departments.Add(new Department(i, nEmp));
                for (int j=1; j <= nEmp; j++)
				{
                    Employees.Add(new Employee(totalEmployees++,                        // уникальный номер сотрудника
                                               $"Имя_{r.Next(1, 1000)}",                // Имя
                                               $"Фамилия_{r.Next(1, 100_000)}",         // Фамилия
                                               r.Next(19, 60),                          // возраст
                                               i,                                       // номер отдела
                                               r.Next(4, 21) * 5_000,                   // зарплата
                                               r.Next(1, 6)));                          // кол-во проектов
				}
			}
		}

        public void PrintDepts()
		{
            foreach (var d in Departments)
                Console.WriteLine(d.ToString());
		}

        public void PrintEmployees()
		{
            foreach (var e in Employees)
                Console.WriteLine(e.ToString());
		}
    }
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
            Apple.GenerateDeptAndEmployees(10, 20);
            Apple.PrintDepts();
            Apple.PrintEmployees();




        }
    }
}
