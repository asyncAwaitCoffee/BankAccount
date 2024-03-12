using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public interface IClientsRepository
    {
        ClientModel? FindClientById(int clientId);
    }
}