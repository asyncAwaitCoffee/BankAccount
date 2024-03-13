using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryAccountsRepository : IAccountsRepository
    {
        private List<AccountModel> _accounts = [
            new("AB-1234567890", 500),
            new("CD-1234567890", 20),
            new("EF-1234567890", 1000),
            new("GH-1234567890", 120),
            new("IJ-1234567890", 950),
            ];

        public AccountModel? FindAccountById(int accountId)
        {
            return _accounts.Find(a => a.Id == accountId);
        }

        public bool TransferBetweenAccountsByAccountId(int accountIdFrom, int accountIdTo, decimal amount)
        {
            AccountModel? accountFrom = FindAccountById(accountIdFrom);
            AccountModel? accountTo = FindAccountById(accountIdTo);

            if (accountFrom == null || accountTo == null)
            {
                return false;
            }

            if (accountFrom.Withdraw(amount))
            {
                if (!accountTo.Deposit(amount))
                {
                    accountFrom.Deposit(amount);
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
