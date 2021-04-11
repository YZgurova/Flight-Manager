using Flight_Manager.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Data.Models
{
    //Клас - таблица User наследяваща IdentityUser
    public class User : IdentityUser
    {
        /// <summary>
        /// Поле за Име на User-а
        /// </summary>
        [Required(ErrorMessage ="First name is required")]        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        //Поле за фамилия 
        public string LastName { get; set; }
        [StringLength(10)]

        // ID поле(уникално)
        public string PersonalId { get; set; }
        //Поле за Адрес
        public string Addres { get; set; }
    }
}
