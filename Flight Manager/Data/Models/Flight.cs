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
        /// <summary>
        /// Конструктор на Flight
        /// </summary>
        public Flight()
        {
             
        }
        public int Id { get; set; }
        /// <summary>
        /// //Поле за локаця на тръгване
        /// </summary>
        [Required(ErrorMessage ="Please type from where will be this flight")]
        
        public string LocationFrom { get; set; }
        /// <summary>
        /// //Поле за локаця на пристигане
        /// </summary>
        [Required(ErrorMessage = "Please type from where will be end this flight")]
        public string LocationTo { get; set; }
        //Поле (падащо меню) за избор на време на тръгване
        public DateTime Takeoff { get; set; }

        //Поле (падащо меню) за избор на време на кацане
        public DateTime Landing { get; set; }

        //Id на самолета (Уникално)
        public string PlaneId { get; set; }
        //Поле от тип клас PlaneType за вида на самолета
        public PlaneType planeType { get; set; }
        //Име на пилот
        public string PilotName { get; set; }
        //Поле, колко е броят на свободните неща
        public int CountOfFreePosition { get; set; }
        //Поле за свободните места
        public int BusinessClassFreePositions { get; set; }
    }
}
