namespace WebBank2App.Models
{
	public class AccountModel(string code, decimal balance = 0)
	{
		private static int idCounter = 0;
		public int Id { get; init; } = ++idCounter;
		public string Code { get; init; } = code;
        public decimal Balance { get; private set; } = balance;
		public bool Withdraw(decimal amount)
		{
			if (Balance < amount)
			{
				return false;
			}
			Balance -= amount;
			return true;
		}
		public bool Deposit(decimal amount)
		{
			Balance += amount;
			return true;
		}
	}
}
