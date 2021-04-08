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

        [HttpPost]
        [Authorize]
        public IActionResult Create(FlightInputModel model)
        {
            this.flightService.Create(model);
            return Redirect("/");
        }

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

        [HttpPost]
        [Authorize] //prowerqwa dali si w profil ili ne
        public IActionResult Edit(FlightEditModel model, int id)
        {
            this.flightService.Update(model, id);
            return Redirect("/");
        }

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
