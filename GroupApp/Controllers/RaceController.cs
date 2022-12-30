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
        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetAllRacesById(id);
            if (race == null) return View("Error");
            var clubM = new EditRaceModel
            {
                Title = race.Title,
                Description = race.Description,
                Image = race.Image,
                AddressId = race.AddressId,
                Address = race.Address,
                RaceCategory = race.RaceCategory
            };
            return View(clubM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceModel raceM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", raceM);
            }

            var userRace = await _raceRepository.GetRaceByIdNoTracking(id);

            if (userRace != null)
            {
                var race = new Race
                {
                    Id = id,
                    Title = raceM.Title,
                    Description = raceM.Description,
                    Image = raceM.Image,
                    AddressId = raceM.AddressId,
                    Address = raceM.Address
                };

                _raceRepository.Update(race);
                return RedirectToAction("Index");
            }
            else
            {
                return View(raceM);
            }
        }
    }
}
