using Flight_Manager.Models;
using Flight_Manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightService flightService;

        /// <summary>
        /// Конструктор на HomeController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="flightService"></param>
        public HomeController(ILogger<HomeController> logger, IFlightService flightService)
        {
            _logger = logger;
            this.flightService = flightService;
        }
        /// <summary>
        /// Извежда всички резерваций.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var flights = flightService.All();
            return View(flights);
        }
        /// <summary>
        /// Извежда изгледа за защита.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Извежда грешка при невалидна оферта.
        /// </summary>
        /// <returns></returns>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
