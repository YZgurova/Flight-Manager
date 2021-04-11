using Flight_Manager.Data;
using Flight_Manager.Data.Models;
using Flight_Manager.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext context;

        public ReservationService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                FlightId=model.FlightId,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            this.context.Reservations.Add(reservation);
            this.context.SaveChanges();
        }
    }
}
