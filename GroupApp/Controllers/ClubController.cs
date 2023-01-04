using GroupApp.Interfaces;
using GroupApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class ClubController : Controller
	{
        private readonly IClubRepository _clubRepository;
		private readonly IHttpContextAccessor _contextAccessor;

        public ClubController(IClubRepository clubRepository, IHttpContextAccessor httpContextAccessor)
		{
            _clubRepository = clubRepository;
			_contextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
		{
			IEnumerable<Club> clubs = await _clubRepository.GetAllClubs();

			return View(clubs);
		}
		public async Task<IActionResult> Detail(int id)
		{
			Club club = await _clubRepository.GetClubById(id);
			return View(club);
		}
		public IActionResult Create()
		{
			var curUser = _contextAccessor.HttpContext?.User.GetUserId();
			var createClub = new Club { AppUserId = curUser };
			return View(createClub);
		}
        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
			}
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
		public async Task<IActionResult> Edit(int id)
		{
			var club = await _clubRepository.GetClubById(id);
			if (club == null) return View("Error");
			var clubM = new EditClubModel
			{
				Title = club.Title,
				Description = club.Description,
                Image = club.Image,
				AppUserId = club.AppUserId,
                AddressId = club.AddressId,
				Address = club.Address,
				ClubCategory = club.ClubCategory
			};
			return View(clubM);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, EditClubModel clubM)
		{
			if (!ModelState.IsValid) 
			{
				ModelState.AddModelError("", "Failed to edit club");
				return View("Edit", clubM);
			}

			var userClub = await _clubRepository.GetClubByIdNoTracking(id);

			if(userClub != null)
			{
				var club = new Club
				{
					Id = id,
					Title = clubM.Title,
					Description = clubM.Description,
					Image = clubM.Image,					
					AddressId = clubM.AddressId,
					Address = clubM.Address
				};

				_clubRepository.Update(club);
				return RedirectToAction("Index");				
			}
			else
			{
				return View(clubM);
			}
        }
	} 
}
