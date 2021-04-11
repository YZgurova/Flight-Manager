using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class CompanyController : Controller
    {
        /// <summary>
        /// Контролер на CompanyController
        /// </summary>
        public CompanyController()
        {

        }
        /// <summary>
        /// Показва първата страница.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Показва страницата за Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Показва страницата за Регистрация
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

    }
}
