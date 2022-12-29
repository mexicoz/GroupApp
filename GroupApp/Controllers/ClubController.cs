﻿using GroupApp.Interfaces;
using GroupApp.Models;
using Microsoft.AspNetCore.Mvc;

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
		public IActionResult Create()
		{
			return View();
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
	} 
}
