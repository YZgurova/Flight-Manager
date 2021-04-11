using Flight_Manager.Data;
using Flight_Manager.Data.Models;
using Flight_Manager.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Services
{
    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Конструктор на FlightService
        /// </summary>
        /// <param name="context"></param>
        public FlightService(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Взима всички полети в списък.
        /// </summary>
        /// <returns></returns>
        public IList<FlightViewModel> All()
        => this.context.Flights
            .Select(p => new FlightViewModel()
            {
                Id = p.Id,
                PlaneId = p.PlaneId,
                LocationFrom = p.LocationFrom,
                LocationTo = p.LocationTo,
                Takeoff = p.Takeoff,
                Landing = p.Landing,
                planeType = p.planeType,
                PilotName = p.PilotName,
                CountOfFreePosition = p.CountOfFreePosition,
                BusinessClassFreePositions = p.BusinessClassFreePositions
            })
            .ToList();

        /// <summary>
        /// Създава полет в базата.
        /// </summary>
        /// <param name="model"></param>
        public void Create(FlightInputModel model)
        {
            var flight = new Flight()
            {
                LocationFrom = model.LocationFrom,
                LocationTo = model.LocationTo,
                Takeoff = model.Takeoff,
                Landing = model.Landing,
                planeType = model.planeType,
                PlaneId = model.PlaneId,
                PilotName = model.PilotName,
                CountOfFreePosition = model.CountOfFreePosition,
                BusinessClassFreePositions = model.BusinessClassFreePositions
            };
            this.context.Flights.Add(flight);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Изтрива даден полет по ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var flight = this.context.Flights.Find(id);
            this.context.Flights.Remove(flight);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Връща полета и данните за него. Намира я по ID(уникално)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FlightDetailModel GetByID(int id)
        {
            var flight = this.context.Flights.Find(id);
            return new FlightDetailModel()
            {
                Id = flight.Id,
                LocationFrom = flight.LocationFrom,
                LocationTo = flight.LocationTo,
                Takeoff = flight.Takeoff,
                Landing = flight.Landing,
                planeType = flight.planeType,
                PlaneId = flight.PlaneId,
                PilotName = flight.PilotName,
                CountOfFreePosition = flight.CountOfFreePosition,
                BusinessClassFreePositions = flight.BusinessClassFreePositions
            };
        }
        /// <summary>
        /// Намира полета по ID и прави промени по данните и.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        public void Update(FlightEditModel model, int id)
        {
            var flight = this.context.Flights.Find(id);
            flight.LocationFrom = model.LocationFrom;
            flight.LocationTo = model.LocationTo;
            flight.Takeoff = model.Takeoff;
            flight.Landing = model.Landing;
            flight.planeType = model.planeType;
            flight.PlaneId = model.PlaneId;
            flight.PilotName = model.PilotName;
            flight.CountOfFreePosition = model.CountOfFreePosition;
            flight.BusinessClassFreePositions = model.BusinessClassFreePositions;
            this.context.Flights.Update(flight);
            this.context.SaveChanges();
        }
        /// <summary>
        /// Променя резервирани билети
        /// </summary>
        /// <param name="id"></param>
        public void UpdateAvailableTickets(int id)
        {
            var flight = this.context.Flights.Find(id);
            flight.CountOfFreePosition--;
            this.context.Flights.Update(flight);
            this.context.SaveChanges();
        }
        /// <summary>
        /// Връща броя на празната позиция
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int FreePositions(int id)
        {
            return this.context.Flights.Find(id).CountOfFreePosition;
        }
    }
}
