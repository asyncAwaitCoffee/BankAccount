using Microsoft.AspNetCore.Mvc;

namespace WebBank2App.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Credits()
        {
            return View();
		}
		public IActionResult Deposits()
		{
			return View();
		}
		public IActionResult Cards()
		{
			return View();
		}
	}
}
