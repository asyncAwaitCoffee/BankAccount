using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryClientsRepository : IClientsRepository
    {
        private List<ClientModel> _users = [
                new("Tom"),
                new("Kate"),
                new("Sarah"),
            ];

        public ClientModel? FindClientById(int clientId)
        {
            return _users.Find(c => c.Id == clientId);
        }
    }
}
