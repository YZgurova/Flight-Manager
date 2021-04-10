using Flight_Manager.Common;
using Flight_Manager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    [Authorize(Roles =GlobalConstants.Roles.Admin)]
    public class EmployeeController : Controller
    {
        private readonly UserManager<User> userManager;

        public EmployeeController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> All() 
        {
            IEnumerable<User> users = await this.userManager.GetUsersInRoleAsync(GlobalConstants.Roles.User);
            return this.View(users);
        }

        public async Task<IActionResult> Delete(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);
            await this.userManager.DeleteAsync(user);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
