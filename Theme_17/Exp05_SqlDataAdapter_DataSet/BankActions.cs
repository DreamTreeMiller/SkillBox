using Interfaces_Actions;

namespace Exp05_SqlDataAdapter_DataSet
{
	public class BankActions
	{
		public IClientsActions Clients;
		public IAccountsActions Accounts;
		public ITransactions Log;
		public ISearch Search;

		//private GoodBankDB bank = new GoodBankDB();

		public BankActions(GoodBank bank)
		{

			Clients = bank as IClientsActions;
			Accounts = bank as IAccountsActions;
			Log = bank as ITransactions;
			Search = bank as ISearch;
		}
	}
}
