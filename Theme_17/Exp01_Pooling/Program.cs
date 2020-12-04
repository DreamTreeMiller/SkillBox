using System;
using static System.Console;
using System.Data.SqlClient;
using System.Configuration;

namespace Exp01_Pooling
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Data.IDbCommand a;

			string cs1 = ConfigurationManager.ConnectionStrings["DefaultConfiguration"].ConnectionString;

			WriteLine($"con string 1: {cs1}");
			SqlConnection scon1 = null;

			//using (scon1 = new SqlConnection(cs1))
			//{
			try
			{
				scon1 = new SqlConnection(cs1);
				scon1.Open();
				WriteLine();
				WriteLine("try block");
				WriteLine($"Connection 1 = {scon1.ClientConnectionId}");
			}
			catch(Exception ex)
			{
				WriteLine();
				WriteLine("catch block");
				WriteLine("Exception occured!!!");
				WriteLine("Type of exception: " + ex.Message);
				WriteLine("Connection state = " + scon1.State);
			}
			finally
			{
				WriteLine();
				WriteLine("finally block");
				WriteLine("Connection state = " + scon1.State);
			}

			try
			{
				scon1.ChangeDatabase("aaa");
			}
			catch (Exception ex)
			{
				WriteLine();
				WriteLine("catch block");
				WriteLine("Exception occured!!!");
				WriteLine("Type of exception: " + ex.Message);
				WriteLine("Connection state = " + scon1.State);
			}
			finally
			{
				WriteLine();
				WriteLine("finally block");
				WriteLine("Connection state = " + scon1.State);
			}
			//}
		}
	}
}
/*
		static void Main(string[] args)
		{
			System.Data.IDbCommand a;

			string cs1 = ConfigurationManager.ConnectionStrings["DefaultConfiguration"].ConnectionString;
			string cs2 = "Data Source=.;Initial Catalog=MyDB;Integrated Security=true;Pooling=true";
			string cs3 = new SqlConnectionStringBuilder()
			{
				DataSource = "DREAMTREE",
				InitialCatalog = "MyDB",
				IntegratedSecurity = true,
				Pooling = true
			}.ConnectionString;
			string cs4 = new SqlConnectionStringBuilder()
			{
				DataSource = ".",
				InitialCatalog = "MyDB",
				IntegratedSecurity = true,
				Pooling = true
			}.ConnectionString;

			Console.WriteLine($"con string 1: {cs1}");
			Console.WriteLine($"con string 2: {cs2}");
			Console.WriteLine($"con string 3: {cs3}");
			Console.WriteLine($"con string 4: {cs4}");
			Console.WriteLine();

			SqlConnection scon1;
			SqlConnection scon2;
			SqlConnection scon3;
			SqlConnection scon4;
			using (scon1 = new SqlConnection(cs1))
			{
				scon1.Open();
				Console.WriteLine($"Connection 1 = {scon1.ClientConnectionId}");


				scon2 = new SqlConnection(cs2);
				scon2.Open();
				Console.WriteLine($"Connection 2 = { scon2.ClientConnectionId}");
				Console.WriteLine($"Con1 status = {scon1.State}");
				Console.WriteLine($"Con2 status = {scon2.State}");
			}
			Console.WriteLine();
			Console.WriteLine("Using statement finished");
			Console.WriteLine($"Con1 status = {scon1.State}");
			Console.WriteLine($"Con2 status = {scon2.State}");
			Console.WriteLine();

			scon3 = new SqlConnection(cs3);
			scon3.Open();
			Console.WriteLine($"Connection 3 = { scon3.ClientConnectionId}");
			Console.WriteLine($"Con3 status = {scon3.State}");
			scon4 = new SqlConnection(cs4);
			scon4.Open();
			Console.WriteLine($"Connection 4 = { scon4.ClientConnectionId}");
			Console.WriteLine($"Con4 status = {scon4.State}");



		}
 */