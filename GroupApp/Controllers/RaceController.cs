using GroupApp.Interfaces;
using GroupApp.Models;
using GroupApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class RaceController : Controller
	{
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
		{
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
		{
			IEnumerable<Race> races = await _raceRepository.GetAllRaces();

			return View(races);
		}
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetAllRacesById(id);
            return View(race);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }
    }
}
