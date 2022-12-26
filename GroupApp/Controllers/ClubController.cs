using GroupApp.Data;
using GroupApp.Interfaces;
using GroupApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Controllers
{
	public class ClubController : Controller
	{
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
		{
            _clubRepository = clubRepository;
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
	} 
}
