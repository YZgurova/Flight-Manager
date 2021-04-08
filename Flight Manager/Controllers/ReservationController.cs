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
                return Redirect("/Flight/Details/" + id);
            }
            this.flightService.UpdateAvailableTickets(id);
            return Redirect("/");
        }


    }
}