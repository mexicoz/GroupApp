using GroupApp.Interfaces;
using GroupApp.Models;
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
				Mileage = user.Mileage,
				ProfileImageUrl = user.ProfileImageUrl,
				City = user.City,
				State = user.State
			};
			return View(editUserVM);
		}
		private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM)
		{
			user.Id = editVM.Id;
			user.Pace = editVM.Pace;
			user.Mileage = editVM.Mileage;
			user.ProfileImageUrl = editVM.ProfileImageUrl;
			user.City = editVM.City;
			user.State = editVM.State;
        }
		[HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editMV)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit profile");
				return View("EditUserProfile", editMV);
			}
			var user = await _repository.GetUserByIdNoTracking(editMV.Id);


			if (user != null)
			{
				MapUserEdit(user, editMV);

                _repository.Update(user);
                return RedirectToAction("Index");
            }
			else
			{
                _repository.Update(user);
                return RedirectToAction("Index");
            }
		}
    }
}
