using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class RaceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
