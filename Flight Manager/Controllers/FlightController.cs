using Flight_Manager.Models.Flights;
using Flight_Manager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;
        /// <summary>
        /// Контролер на FlightService
        /// </summary>
        /// <param name="flightService"></param>
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Извежда изгледа за създаване
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Create(FlightInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            this.flightService.Create(model);
            return Redirect("/");
        }
        /// <summary>
        /// Променя и пренасочва изгледа.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult Edit(int id)
        {
            var flight = this.flightService.GetByID(id);
            return this.View(new FlightEditModel() {
                LocationFrom = flight.LocationFrom,
                LocationTo = flight.LocationTo,
                Takeoff = flight.Takeoff,
                Landing = flight.Landing,
                planeType = flight.planeType,
                PilotName = flight.PilotName,
                CountOfFreePosition = flight.CountOfFreePosition,
                BusinessClassFreePositions = flight.BusinessClassFreePositions
            });
        }

        /// <summary>
        /// Проверява дали е в профил или не
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize] 
        public IActionResult Edit(FlightEditModel model, int id)
        {
            this.flightService.Update(model, id);
            return Redirect("/");
        }

        /// <summary>
        /// Изтрива и пренасочва изгледа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(Delete) + "/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            this.flightService.Delete(id);
            return Redirect("/");
        }

        public IActionResult Details(int id)
        {
            var flight = this.flightService.GetByID(id);
            return this.View(flight);           
        }


    }
}
