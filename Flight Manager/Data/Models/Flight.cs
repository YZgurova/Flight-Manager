using Flight_Manager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Data.Models
{
    public class Flight
    {

        public Flight()
        {

        }
        public int Id { get; set; }

        [Required]
        public string LocationFrom { get; set; }

        public string LocationTo { get; set; }

        public DateTime Takeoff { get; set; }

        public DateTime Landing { get; set; }
        public string PlaneId { get; set; }
        
        public PlaneType planeType { get; set; }       
        
        public string PilotName { get; set; }
        
        public int CountOfFreePosition { get; set; }
        
        public int BusinessClassFreePositions { get; set; }
    }
}
