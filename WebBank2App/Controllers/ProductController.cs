using Microsoft.AspNetCore.Mvc;

namespace WebBank2App.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
        {
            return View();
		}
	}
}
