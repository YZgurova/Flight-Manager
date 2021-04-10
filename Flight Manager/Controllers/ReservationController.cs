using Flight_Manager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IFlightService flightService;
        public ReservationController(IFlightService flightService)
        {
            this.flightService = flightService;
        }


        public IActionResult UpdateAvailableTicket(int id)
        {
            if (this.flightService.GetByID(id).CountOfFreePosition-1<0)
            {
                ModelState.AddModelError(String.Empty, "No more free positions");                
            }
            if (!ModelState.IsValid)
            {
                return Redirect("/Reservation/Unsuccessfull");
            }
            this.flightService.UpdateAvailableTickets(id);
            return Redirect("/Reservation/Successfull");
        }

        
        public IActionResult Unsuccessfull()
        {
            return View();
        }

        
        public IActionResult Successfull()
        {
            return View();
        }
        
    }
}