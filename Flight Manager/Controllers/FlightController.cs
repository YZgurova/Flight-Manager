using Flight_Manager.Models.Flights;
using Flight_Manager.Services;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FlightInputModel model)
        {
            this.flightService.Create(model);
            return Redirect("/");
        }

        [HttpGet(nameof(Edit) + "/{id}")]
        public IActionResult Edit(FlightEditModel model, int id)
        {
            this.flightService.Update(model, id);
            return Redirect("/");
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            this.flightService.Delete(id);
            return Redirect("/");
        }

    }
}
