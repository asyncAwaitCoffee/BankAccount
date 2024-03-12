namespace WebBank2App.Models
{
	public record class ClientModel(string Name)
	{
		private static int idCounter = 0;
		public int Id { get; init; } = ++idCounter;
    }
}
