using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1742
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MSSQLLocalDemo;Integrated Security=True
            SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo",
                IntegratedSecurity = true,
                Pooling = true
            };



            using (SqlConnection connection = new SqlConnection(strCon.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string[] sqls =
                    {

                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 1', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 2', 1, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 3', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 4', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 5', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 6', 2, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 7', 2, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 8', 2, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 9', 2, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 10', 3, 3)",



                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 11', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 12', 1, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 13', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 14', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 15', 1, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 16', 2, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 17', 2, 1)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 18', 2, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 19', 2, 2)",
                        "INSERT INTO [dbo].[Workers] ([workerName], [idBoss], [idDescription]) VALUES (N'Сотрудник 20', 3, 3)"

                    };

                    SqlCommand command;
     //               foreach (var sql in sqls)
     //               {
     //                   command = new SqlCommand(sql, connection);
     //                   command.ExecuteNonQuery();
					//}

						#region sql ex

						string ss = @"UPDATE Workers SET workerName = N'Новое имя' WHERE id = 19";

						command = new SqlCommand(ss, connection);
						command.ExecuteNonQuery();

						ss = @"DELETE FROM Workers WHERE id > 15";

						command = new SqlCommand(ss, connection);
						command.ExecuteNonQuery();

						#endregion
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Done");
                }
            }
        }
    }
}