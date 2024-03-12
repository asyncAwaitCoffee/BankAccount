using WebBank2App.DTO;
using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public interface IAccountsRepository
    {
        public AccountModel? FindAccountById(int accountId);
        bool TransferBetweenAccountsByAccountId(int accountIdFrom, int accountIdTo, decimal amount);
    }
}