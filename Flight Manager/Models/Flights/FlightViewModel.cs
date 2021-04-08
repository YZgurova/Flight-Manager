using Flight_Manager.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Models.Flights
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string LocationFrom { get; set; }

        public string LocationTo { get; set; }

        public DateTime Takeoff { get; set; }

        public DateTime Landing { get; set; }

        public PlaneType planeType { get; set; }

        public string PlaneId { get; set; }

        public string PilotName { get; set; }

        public int CountOfFreePosition { get; set; }

        public int BusinessClassFreePositions { get; set; }
    }
}
