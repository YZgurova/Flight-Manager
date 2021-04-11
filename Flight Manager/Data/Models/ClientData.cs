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
        //Име на клиента
        public string FirstName { get; set; }
        // Презиме на клиента
        public string MiddleName { get; set; }
        //Фамилия на клиента
        public string LastName { get; set; }
        [Key]
        //ID поле(уникално)
        public string PersonalId { get; set; }
        //Поле за телефонен номер
        public string TelephoneNumber { get; set; }
        public string Nationality { get; set; }
        //Поле от тип TicketType за вид на билета 
        public TicketType ticketType { get; set; }
    }
}
