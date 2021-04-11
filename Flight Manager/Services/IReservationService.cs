using Flight_Manager.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Services
{
    public interface IReservationService
    {
        void Create(ReservationViewModel model);

    }
}
