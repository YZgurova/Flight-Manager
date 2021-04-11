using Flight_Manager.Models.Reservation;
using Flight_Manager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IFlightService flightService;
        private readonly IReservationService reservationService;
        private readonly IEmailSender emailSender;

        public ReservationController(IFlightService flightService, IReservationService reservationService, IEmailSender emailSender)
        {
            this.flightService = flightService;
            this.reservationService = reservationService;
            this.emailSender = emailSender;
        }


        public IActionResult ReservationPage()
        {
            return View(new ReservationViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> ReservationPage(int id, ReservationViewModel model)
        {
            if (this.flightService.GetByID(id).CountOfFreePosition - 1 < 0)
            {
                ModelState.AddModelError(String.Empty, "No more free positions");
            }
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            this.flightService.UpdateAvailableTickets(id);
            model.FlightId = id;
            this.reservationService.Create(model);
            var flight = this.flightService.GetByID(id);
            var messageBody = new StringBuilder();
            messageBody.AppendLine("Successfull Reservation" + Environment.NewLine);
            messageBody.AppendLine("Flight Destination:" + flight.LocationFrom+"-"+flight.LocationTo + Environment.NewLine);
            messageBody.AppendLine("Duration:" + (flight.Landing - flight.Takeoff));
            await this.emailSender.SendEmailAsync(model.Email, "Successfull reservation", messageBody.ToString());
            return Redirect("/Flight/Details/"+ id);
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