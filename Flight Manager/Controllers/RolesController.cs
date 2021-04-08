using Flight_Manager.Data;
using Flight_Manager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Manager.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> manager;
        private readonly SignInManager<User> signInManager;

        public ActionResult<List<IdentityRole>> Index()
        {
            var userId = this.manager.GetUserId(this.User);
            var userRoles = context.UserRoles.Where(ur => ur.UserId==userId);
            var roles = context.Roles.Where(r => userRoles.Any(ur => ur.RoleId==r.Id));
            return roles.ToList();
        }
        public RolesController(ApplicationDbContext context, UserManager<User> manager, SignInManager<User> signInManager)
        {

            this.context = context;
            this.manager = manager;
            this.signInManager = signInManager;
        }
    }
}
