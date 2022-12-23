using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class ClubController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
