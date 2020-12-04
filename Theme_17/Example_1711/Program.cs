using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Example_1711
{
    class Program
    {
        static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            // 
            // Создание БД
            // База данных — некоторый набор постоянно хранимых данных, используемых прикладными 
            // программными системами какого-либо владеельца.

            // MSSQLLocalDB (localdb)\MSSQLLocalDB
            // За подключение к источнику отвечает группа компонентов Connection
            // 1. Создать строку подключения - набор пар (параметр, значение)
            //
            // Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MSSQLLocalDemo; Integrated Security = True; Pooling = False
            // Data Source = .;                      Initial Catalog  =master;         Integrated Security = True
            // Data Source = DREAMTREE\;             Initial Catalog = MyDB;           Integrated Security = True
            // Data Source = .\SQLEXPRESS;           Initial Catalog = expressDB;Integrated Security=True
            // Data Source = (localdb)\MSSQLLocalDB; 
            // имя сервера источника данных, к которому нужно подключиться

            // Initial Catalog = MSSQLLocalDemo;        
            // к какой именно БД подключиться

            // Integrated Security = True         
            // указывает правило авторизации
            // UserID и Password
            // Pooling = False                      
            // указывает нужно ли использовать пул подключений
            // и др
            //

            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @".\SQLEXPRESS",
                InitialCatalog = "aaaa",
                IntegratedSecurity = true,
                // UserID = "Admin", Password = "qwerty",
                // Pooling = false
            };

            Console.WriteLine($"Строка подключения: {strCon.ConnectionString}");
            Console.ReadKey();

            using (var sqlConnection = new SqlConnection(strCon.ConnectionString))
            {
                sqlConnection.StateChange +=
                    (s, e) =>
                    {
                        Console.WriteLine($@"{nameof(sqlConnection)} в состоянии:" +
                                           $" {(s as SqlConnection).State}");
                    };

                try
                {
                    sqlConnection.Open(); // Открыть соединение с БД Console.WriteLine(sqlConnection.State);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // Console.WriteLine(sqlConnection.State);
                }
            }
            //finally
            //{
            //    sqlConnection.Close();// Закрыть соединение с БД Console.WriteLine(sqlConnection.State);
            //}








        }
    } 
}
