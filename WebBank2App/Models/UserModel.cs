namespace WebBank2App.Models
{
    public record class UserModel(string UserName, string Password, int ClientId)
    {
        private static int _idCounter = 0;
        public int Id { get; init; } = ++_idCounter;
    }
}
