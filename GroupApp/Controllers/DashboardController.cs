﻿using GroupApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
	public class DashboardController : Controller
	{
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
		{
            _context = context;
        }
		public IActionResult Index()
		{
			return View();
		}
	}
}
