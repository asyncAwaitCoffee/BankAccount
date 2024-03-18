using System.ComponentModel.DataAnnotations;
using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryUsersRepository : IUsersRepository
    {
		private static int _idCounter = 0;

		private List<UserModel> _users = [
            new("qwe", "123", 1) { Id = ++_idCounter},
            new("asd", "123", 2) { Id = ++_idCounter},
            new("zxc", "123", 3) { Id = ++_idCounter},
            ];

        public int? TryLogin(string userName, string password)
        {
            return _users.Find(u => u.UserName == userName && u.Password == password)?.Id;
        }
        public int? GetClientId(int userId)
        {
            return _users.Find(u => u.Id == userId)?.ClientId;
        }
        public int TryRegister(string userName, string password, int clientId)
        {
            UserModel newUser = new(userName, password, clientId);
            // TODO - validation handle
            List<ValidationResult> errors = [];
            if (!Validator.TryValidateObject(newUser, new(newUser), errors, true))
            {
                foreach (var item in errors)
                {
                    Console.WriteLine(item);
                }
            }
			newUser.Id = ++_idCounter;

			_users.Add(newUser);
            return newUser.Id;
		}
    }
}
