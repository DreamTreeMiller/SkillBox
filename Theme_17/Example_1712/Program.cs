using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1712
{
    class Program
    {
        static void Main(string[] args)
        {

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo",
                IntegratedSecurity = true,
                // UserID = "Admin", Password = "qwerty"
                Pooling = !false
            };

            Console.WriteLine($"Строка подключения: {strCon.ConnectionString}");


            SqlConnection sqlConnection = new SqlConnection(strCon.ConnectionString);
			// Data Source=DREAMTREE\;Initial Catalog=MyDB;Integrated Security=True
			SqlConnectionStringBuilder str1 = new SqlConnectionStringBuilder()
			{
				DataSource = @"DREAMTREE",
				InitialCatalog = "MyDB",
				IntegratedSecurity = true,
				Pooling = true
			};

			var con1 = new SqlConnection(str1.ConnectionString);
			con1.Open();
			Console.WriteLine($"Строка подключения con1: {str1.ConnectionString}");
			Console.WriteLine($"con1 Data Source     = {con1.DataSource}");
			Console.WriteLine($"con1 Initial Catalog = {con1.Database}");
			Console.WriteLine($"con1 Status			 = {con1.State}");
			Console.WriteLine();

			SqlConnectionStringBuilder str2 = new SqlConnectionStringBuilder()
			{
				DataSource = @".",
				InitialCatalog = "MyDB",
				IntegratedSecurity = true,
				Pooling = true
			};

			var con2 = new SqlConnection(str2.ConnectionString);
			con2.Open();
			Console.WriteLine($"Строка подключения con2: {str2.ConnectionString}");
			Console.WriteLine($"con2 Data Source     = {con2.DataSource}");
			Console.WriteLine($"con2 Initial Catalog = {con2.Database}");
			Console.WriteLine($"con2 Status			 = {con2.State}");
			Console.WriteLine();

			var con3 = new SqlConnection(str2.ConnectionString);
			Console.WriteLine($"Строка подключения con3: {str2.ConnectionString}");
			Console.WriteLine($"con3 Data Source     = {con3.DataSource}");
			Console.WriteLine($"con3 Initial Catalog = {con3.Database}");
			Console.WriteLine($"con3 Status			 = {con3.State}");
			Console.WriteLine();

			Console.ReadKey();
			con1.Close();
			con2.Close();
			con3.Close();

			#region Test many pool connections

			//var date = DateTime.Now;

			//int n = 300_000;

			//for (double i = 1; i <= n; i++)
			//{
			//Console.Write(".");
			//sqlConnection = new SqlConnection(strCon.ConnectionString);

			//try
			//{
			//    sqlConnection.Open(); // Открыть соединение с БД 
			//}
			//finally
			//{
			//    sqlConnection.Close();// Закрыть соединение с БД 
			//}
			//}

			//Console.WriteLine($"\n {n} Подключений за ~{(int)(DateTime.Now-date).TotalSeconds} сек.");

			#endregion
		}
	}
}
