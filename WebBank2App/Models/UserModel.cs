using System.ComponentModel.DataAnnotations;

namespace WebBank2App.Models
{
    public record class UserModel(string UserName, string Password, int ClientId)
    {
        private static int _idCounter = 0;
        public int Id { get; init; } = ++_idCounter;
        public bool IsValid() {
            if (
                UserName.Length > 12 || UserName.Length < 3 ||
				Password.Length > 12 || Password.Length < 3
                )
            {
                return false;
            }
            return true;
        }

	}
}
