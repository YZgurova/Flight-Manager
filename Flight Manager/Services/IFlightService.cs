using Flight_Manager.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Services
{
    public interface IFlightService
    {
        void Create(FlightInputModel model);
        
        IList<FlightViewModel> All();
        
        FlightDetailModel GetByID(int id);
        
        void Update(FlightEditModel model, int id);
        
        void UpdateAvailableTicket(int id);
    }
}
