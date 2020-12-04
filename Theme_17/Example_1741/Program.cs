using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1741
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
                Pooling = true
            };


            try
            {
                using (SqlConnection c = new SqlConnection(strCon.ConnectionString))
                {

                    c.Open();
                    var sql = @"
SELECT 
    Workers.id as 'ID',
    Workers.workerName as 'workerName',
    Bosses.workerName  as 'bossesName',
    Bosses.departmentName  as 'departmentName',
    [Description].[value] as 'descriptionValue'
FROM  Workers, Bosses, [Description]
WHERE Workers.idBoss = Bosses.id and Workers.idDescription = [Description].id
";
                    SqlCommand command = new SqlCommand(sql, c);
                    SqlDataReader r = command.ExecuteReader();

                    while (r.Read())
                    {
                        Console.WriteLine($"{r.GetInt32(0) * 10 ,4} | " +
                                          $"{r["workerName"],12} | " +
                                          $"{r[2],11} | " +
                                          $"{r[3], 11} | " +
                                          $"{r[4],12} | ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

 
        }
    }
}
