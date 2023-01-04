using GroupApp.Interfaces;
using GroupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
    public class UserController : Controller
    {
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
        {
			_userRepository = userRepository;
		}
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userVM = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Milage = user.Mileage
                };
                result.Add(userVM);
            }
            return View(result);
        }
    }
}
