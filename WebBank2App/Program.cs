using Microsoft.AspNetCore.Authentication.Cookies;
using WebBank2App.Repositories;
using WebBank2App.Services;

namespace WebBank2App
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => options.LoginPath = "/Auth/Index");
			builder.Services.AddAuthorization();
			builder.Services.AddSingleton<IClientsRepository, MemoryClientsRepository>();
			builder.Services.AddSingleton<ICardsRepository, MemoryCardsRepository>();
			builder.Services.AddSingleton<IAccountsRepository, MemoryAccountsRepository>();
			builder.Services.AddSingleton<ITransfersRepository, MemoryTransfersRepository>();
			builder.Services.AddSingleton<IUsersRepository, MemoryUsersRepository>();
			builder.Services.AddScoped<TextFormatter>();

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
