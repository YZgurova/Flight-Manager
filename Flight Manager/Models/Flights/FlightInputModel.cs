using Flight_Manager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Models.Flights
{
    public class FlightInputModel
    {
        public int Id { get; set; } 
        [Required]
        public string LocationFrom { get; set; }
        [Required]
        public string LocationTo { get; set; }
        [Required]
        public DateTime Takeoff { get; set; }
        [Required]
        public DateTime Landing { get; set; }
        [Required]
        public PlaneType planeType { get; set; }
        [Required]
        public string PlaneId { get; set; }
        [Required]
        public string PilotName { get; set; }
        [Required]
        public int CountOfFreePosition { get; set; }
        [Required]
        public int BusinessClassFreePositions { get; set; }
    }
}
