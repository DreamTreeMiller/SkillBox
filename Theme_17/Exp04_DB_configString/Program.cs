using System;
using static System.Console;
using System.Data.SqlClient;
using System.Configuration;

namespace Exp04_DB_configString
{
	class Program
	{
		static void Main(string[] args)
		{
			string GoodBankCS = GetGoodBankConfigurationString();

			SqlConnectionStringBuilder strBuilder = default;
			// Check if configuration string is correct
			// if not, save GoodBank config string
			try 
			{
				strBuilder = new SqlConnectionStringBuilder(GoodBankCS);
			}
			catch (Exception ex)
			{
				WriteLine("SqlConnectionStringBuilder exception!");
				WriteLine("Exception = " + ex.Message);
				GoodBankCS = CorrectGoodBankCSinConfigFile();
				strBuilder = new SqlConnectionStringBuilder(GoodBankCS);
			}
			string gbdbName = strBuilder.InitialCatalog;
			WriteLine(GoodBankCS);
			WriteLine("Data base name = " + gbdbName);
			Write("Press Enter ..."); ReadLine();

			if (DoesDBExist(gbdbName))
			{
				WriteLine($"Database {gbdbName} already exists");
			}
			else
			{
				WriteLine($"Database {gbdbName} does not exist.");
				CreateDB(gbdbName);
				WriteLine($"Database {gbdbName} was created!");
			}

			using (SqlConnection GoodBankConn = new SqlConnection(GoodBankCS))
			{
				try
				{
					GoodBankConn.Open();
					WriteLine();
					WriteLine($"Database {gbdbName} state = " + GoodBankConn.State);
				}
				catch (Exception ex)
				{
					WriteLine();
					WriteLine($"Exception = {ex.Message}");
				}

				string cmdText = @$"USE {gbdbName};" 
					+ $"SELECT TABLE_NAME FROM [{gbdbName}].INFORMATION_SCHEMA.TABLES"
					;
				SqlCommand cmd = new SqlCommand(cmdText, GoodBankConn);
				SqlDataReader tablesList;
				try
				{
					tablesList = cmd.ExecuteReader();
					while (tablesList.Read())
						WriteLine((string)tablesList[0]);
				}
				catch (Exception ex) 
				{
					WriteLine("Exception " + ex.Message);
				}
			}


		}

		/// <summary>
		/// Reads app.config and gets "GoodBank" configuration string
		/// </summary>
		/// <returns>
		/// Configuration string associated with "GoodBank",
		/// null otherwise
		/// </returns>
		public static string GetGoodBankConfigurationString()
		{
			string GoodBankCS = null;
			// here we set the users connection string for the database
			// Get the application configuration file.
			Configuration config = 
				ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			// Get the connection strings section.
			ConnectionStringsSection csSection = config.ConnectionStrings;

			foreach (ConnectionStringSettings cs in csSection.ConnectionStrings)
				if (cs.Name == "GoodBank")
				{
					GoodBankCS = cs.ConnectionString;
					break;
				}
			if (GoodBankCS == null)
				GoodBankCS = AddGoodBankCSToConfigFile();
			return GoodBankCS;
		}

		/// <summary>
		/// Creates GoodBank entry in configuration file
		/// </summary>
		/// <returns>Configuration string for GoodBank</returns>
		public static string AddGoodBankCSToConfigFile()
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConnectionStringsSection csSection = config.ConnectionStrings;

			var gbcs = new ConnectionStringSettings()
			{
				Name = "GoodBank",
				ConnectionString = new SqlConnectionStringBuilder()
				{
					DataSource = @"(localdb)\MSSQLLocalDB",
					InitialCatalog = "GoodBank",
					IntegratedSecurity = true,
					Pooling = true
				}.ConnectionString,
				ProviderName = "System.Data.SqlClient"
			};
			csSection.ConnectionStrings.Add(gbcs);

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(csSection.SectionInformation.Name);

			return gbcs.ConnectionString;
		}

		/// <summary>
		/// Corrects 'GoodBank' connection string in App.config file if it has mistake
		/// </summary>
		/// <returns></returns>
		public static string CorrectGoodBankCSinConfigFile()
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConnectionStringsSection csSection = config.ConnectionStrings;
			ConnectionStringSettings wrongGB = default;
			foreach(ConnectionStringSettings css in csSection.ConnectionStrings)
				if (css.Name == "GoodBank")
				{
					wrongGB = css;
					break;
				}
			csSection.ConnectionStrings.Remove(wrongGB);

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection(csSection.SectionInformation.Name);

			return AddGoodBankCSToConfigFile();
		}

		/// <summary>
		/// Builds connection string for (localdb)\MSSQLLocalDB server, 'master' database
		/// </summary>
		/// <returns>Connection string</returns>
		public static string GetMasterConnectionString()
		{
			string masterCS = default;
			// here we set the users connection string for the database
			// Get the application configuration file.
			Configuration config =
				ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			// Get the connection strings section.
			ConnectionStringsSection csSection = config.ConnectionStrings;

			foreach (ConnectionStringSettings cs in csSection.ConnectionStrings)
				if (cs.Name == "DefaultConfiguration")
				{
					masterCS = cs.ConnectionString;
					break;
				}
			return (masterCS != null)? 
					masterCS :
					new SqlConnectionStringBuilder()
					{
						DataSource			= @"(localdb)\MSSQLLocalDB",
						InitialCatalog		= "master",
						IntegratedSecurity	= true,
						Pooling				= true
					}.ConnectionString;
		}

		/// <summary>
		/// Checks if a database with the specified name already exists in the server
		/// Server is (localdb)\MSSQLLocalDB
		/// </summary>
		/// <param name="dbName">Database name</param>
		/// <returns>true if a database with specified name exists, false otherwise</returns>
		public static bool DoesDBExist(string dbName)
		{
			bool	result	 = false;
			string	masterCS = GetMasterConnectionString();
			using (SqlConnection masterConn = new SqlConnection(masterCS))
			{
				masterConn.Open();
				string commandStr = @"SELECT database_id, [name] FROM master.sys.databases WHERE database_id > 4;";
				SqlCommand sqlCommand = new SqlCommand(commandStr, masterConn);
				SqlDataReader dbList;
				try
				{
					dbList = sqlCommand.ExecuteReader();
					while (dbList.Read())
						if ((string)dbList["name"] == dbName)
						{
							result = true;
							break;              // need to close connection first
						}
				}
				catch (Exception ex)
				{
					WriteLine();
					WriteLine("Checking if DB exists. Catch block!");
					WriteLine($"Exception = {ex.Message}");
				}
			}
			return result;
		}

		/// <summary>
		/// Creates on the (localdb)\MSSQLLocalDB server a database with the specified name
		/// Does not check, if such database exists. This has to be done prior to db creation
		/// </summary>
		/// <param name="dbName"></param>
		public static void CreateDB(string dbName)
		{
			string masterCS = GetMasterConnectionString();
			using (SqlConnection masterConn = new SqlConnection(masterCS))
			{
				masterConn.Open();
				string cmdLine = $"CREATE DATABASE {dbName};";
				SqlCommand command = new SqlCommand(cmdLine, masterConn);
				try
				{
					command.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					WriteLine();
					WriteLine($"CREATE DATABASE {dbName}; Catch block!!!");
					WriteLine("Exception = " + ex.Message);
				}
			}
		}
	}
}
