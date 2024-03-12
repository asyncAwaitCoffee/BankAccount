using WebBank2App.Repositories;

namespace WebBank2App
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddSingleton<IClientsRepository, MemoryClientsRepository>();
			builder.Services.AddSingleton<ICardsRepository, MemoryCardsRepository>();
			builder.Services.AddSingleton<IAccountsRepository, MemoryAccountsRepository>();

			var app = builder.Build();
			app.UseStaticFiles();

			app.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}"
				);

            app.MapControllerRoute(
                    name: "api-card",
                    pattern: "api/{controller=Account}/{action=Card}/{cardId:int}"
                );

            app.MapControllerRoute(
                    name: "api-transfer",
                    pattern: "api/{controller=Account}/{action=Transfer}"
                );

            app.Run();
		}
	}
}
