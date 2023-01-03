using GroupApp.Interfaces;
using GroupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class DashboardController : Controller
	{
        private readonly IDashboardRepository _repository;

        public DashboardController(IDashboardRepository repository)
		{
            _repository = repository;
        }
		public async Task<IActionResult> Index()
		{
			var userClubs = await _repository.GetAllUserClubs();
			var userRaces = await _repository.GetAllUserRaces();
			var dashboard = new DashboardViewModel()
			{
				Clubs = userClubs,
				Races = userRaces
			};
			return View(dashboard);
		}
	}
}
