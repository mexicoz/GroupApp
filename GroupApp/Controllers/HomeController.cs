using GroupApp.Helpers;
using GroupApp.Interfaces;
using GroupApp.Models;
using GroupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace GroupApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IClubRepository _clubRepository;

        public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository)
		{
			_logger = logger;
            _clubRepository = clubRepository;
        }
		private const string URL_TOKEN = "https://ipinfo.io?token=86f7867313caaf";

        public async Task<IActionResult> Index()
		{
			var ipInfo = new IPInfo();
			var homeVM = new HomeViewModel();
			try
			{
				var info = new WebClient().DownloadString(URL_TOKEN);
				ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
				RegionInfo myRI = new RegionInfo(ipInfo.Country);
				ipInfo.Country = myRI.EnglishName;
				homeVM.City = ipInfo.City;
				homeVM.State = ipInfo.Region;

				if(homeVM.City != null)
				{
					homeVM.Clubs = await _clubRepository.GetClubByCity(homeVM.City);
				}
				else
				{
					homeVM.Clubs = null;
				}
				return View(homeVM);
            }
			catch(Exception ex)
			{
                homeVM.Clubs = null;
            }
			return View(homeVM);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}