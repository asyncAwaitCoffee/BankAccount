using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryClientsRepository : IClientsRepository
    {
        private List<ClientModel> _clients = [
                new("Tom"),
                new("Kate"),
                new("Sarah"),
            ];

        public ClientModel? FindClientById(int clientId)
        {
            return _clients.Find(c => c.Id == clientId);
        }

        public ClientModel AddNewClient(string name)
        {
            ClientModel newClient = new(name);
            _clients.Add(newClient);
            return newClient;
        }
    }
}
