using Flight_Manager.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Data.Models
{
    public class ClientData : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string PersonalId { get; set; }
        public string TelephoneNumber { get; set; }
        public string Nationality { get; set; }
        public TicketType ticketType { get; set; }
    }
}
