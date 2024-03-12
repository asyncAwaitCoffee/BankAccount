using Microsoft.AspNetCore.Mvc;

namespace WebBank2App.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
