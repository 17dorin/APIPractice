using APIPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StarWarsDAL swd = new StarWarsDAL();
        private WeatherDAL wdl = new WeatherDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //string json = swd.GetPerson(1);
            //TempData["json"] = json;
            Person luke = swd.ConvertToPerson(1);
            luke.homeworld = swd.ConvertToHomeworld(luke.homeworld).name;
            return View(luke);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Weather()
        {
            Weather w = wdl.ConvertToWeather("https://api.weather.gov/zones/land/MIZ075/forecast");
            return View(w);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
