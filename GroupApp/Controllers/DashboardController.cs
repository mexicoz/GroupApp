using GroupApp.Interfaces;
using GroupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class DashboardController : Controller
	{
        private readonly IDashboardRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboardRepository repository, IHttpContextAccessor httpContextAccessor)
		{
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
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
		public async Task<IActionResult> EditUserProfile()
		{
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			var user = await _repository.GetUserById(curUserId);
			
			if (user == null) return View("Error");

			var editUserVM = new EditUserDashboardViewModel()
			{
				Id = curUserId,
				Pace = user.Pace,
				Milage = user.Mileage,
				ProfileImageUrl = user.ProfileImageUrl,
				City = user.City,
				State = user.State
			};
			return View(editUserVM);
		}
	}
}
