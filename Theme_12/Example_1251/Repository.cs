﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1251
{

    public class Repository
    {
        static Random r;

        static Repository() { r = new Random(); }

        public List<Worker> WorkersDb { get; set; }
        public List<Department> DepartmentsDb { get; set; }

        private Repository(int CountDepartment, int CountEmployee)
        {
            WorkersDb = new List<Worker>();
            DepartmentsDb = new List<Department>();

            for (int i = 0; i < CountDepartment; i++)
            {
                DepartmentsDb.Add(new Department($"Департамент {i + 1}", i));
            }

            for (int i = 0; i < CountEmployee; i++)
            {
                WorkersDb.Add(
                        new Worker($"Имя_{i + 1}", 
                                     r.Next(18, 30),
                                     r.Next(DepartmentsDb.Count)));
            }

        }


        public static Repository CreateRepository(int CountDepartment = 10, int CountEmployee = 100)
        {
            return new Repository(CountDepartment, CountEmployee);
        }

    }
}
