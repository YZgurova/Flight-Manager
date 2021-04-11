using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Email { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

    }   
}
