namespace WebBank2App.Repositories
{
    public interface IUsersRepository
    {
        int? TryLogin(string username, string password);
        int? GetClientId(int userId);
    }
}