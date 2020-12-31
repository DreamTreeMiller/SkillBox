using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Imitation;

namespace Exp05_SqlDataAdapter_DataSet
{
	class Program
	{
		static GoodBank		  gb;
		static SqlDataAdapter da;
		static DataSet		  ds;
		static DataTable	  dt;
		static BankActions ba;
		static void Main(string[] args)
		{

			Console.InputEncoding = Encoding.Unicode; Console.OutputEncoding = Encoding.Unicode;
			gb = new GoodBank();
			ds = gb.PopulateTables();
			ba = new BankActions(gb); 
			Generate.Bank(ba, 5, 5, 5);

			gb.daVIPclients.Update(ds, "VIPclients");
			gb.daSIMclients.Update(ds, "SIMclients");
			gb.daORGclients.Update(ds, "ORGclients");
			gb.daClients.Update(ds, "Clients");
			Console.SetBufferSize(400, 1000);
			foreach (DataTable t in ds.Tables)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Table = {t}");
				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (DataColumn cn in t.Columns)
					Console.Write($"{cn.ColumnName, 20}");
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Gray;

				foreach(DataRow row in t.Rows)
				{
					foreach(DataColumn cn in t.Columns)
						Console.Write($"{row[cn],20}");
					Console.WriteLine();
				}

				// End of the table
				Console.WriteLine();
			}

			Console.Write("Press Enter ...");
			Console.ReadLine();
		}
	}
}
