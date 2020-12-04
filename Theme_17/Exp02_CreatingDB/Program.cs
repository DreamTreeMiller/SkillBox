using System;
using System.Data;
using System.Data.SqlClient;

namespace Exp02_CreatingDB
{
	class Program
	{
		static void Main(string[] args)
		{
			string connStr = (new SqlConnectionStringBuilder()
			{
				DataSource			= @"(localdb)\MSSQLLocalDB",
				InitialCatalog		= "master",
				IntegratedSecurity	= true
			}).ConnectionString;

			var myConn = new SqlConnection(connStr);
			Console.Write("Enter new database name: ");
			var dbName = Console.ReadLine();
			string createNewDBcommand =
				"CREATE DATABASE"
				+ $" {dbName} "
				+ "";
			var myCommand = new SqlCommand(createNewDBcommand, myConn);
			try 
			{
				myConn.Open();
				myCommand.ExecuteNonQuery();
				Console.WriteLine($"Database {dbName} was created successfully");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			Console.Write("Enter database name to check existence: ");
			dbName = Console.ReadLine();

			string existCmdStr = $"SELECT DB_ID('{dbName}')";
			var existCmd = new SqlCommand(existCmdStr, myConn);
			try 
			{
				object db_id = existCmd.ExecuteScalar();
				if ( db_id != DBNull.Value)
				{
					Console.WriteLine($"Database {dbName} exists with id = {db_id}");
				}
				else
				{
					Console.WriteLine($"Database {dbName} DOESN'T exists. Return value {(db_id == null?"NULL":(string)db_id)}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception message: {ex.Message}");
			}
			finally
			{
				if (myConn.State == ConnectionState.Open)
				{
					myConn.Close();
				}
			}
			Console.WriteLine("Done!");
		}
	}
}
