using GroupApp.Data;
using GroupApp.Interfaces;
using GroupApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Controllers
{
	public class RaceController : Controller
	{
        private readonly IRaceRepository raceRepository;

        public RaceController(IRaceRepository raceRepository)
		{
            this.raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
		{
			IEnumerable<Race> races = await raceRepository.GetAllRaces();

			return View(races);
		}
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await raceRepository.GetAllRacesById(id);
            return View(race);
        }
    }
}
