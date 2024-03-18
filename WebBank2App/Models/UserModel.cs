using System.ComponentModel.DataAnnotations;

namespace WebBank2App.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 3)]
		public string Password { get; set; }
		[Required]        
		public int ClientId { get; set; }
        public UserModel(string userName, string password, int clientId)
        {
            UserName = userName;
            Password = password;
            ClientId = clientId;
        }
        private static int _idCounter = 0;
        public int Id { get; init; } = ++_idCounter;


	}
}
