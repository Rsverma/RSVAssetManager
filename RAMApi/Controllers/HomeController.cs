using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RAMApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RAMApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //string[] roles = { "Admin", "FundManager", "Trader" };
            //var user = await _userManager.FindByEmailAsync("rsverma333@gmail.com");
            //foreach(var role in roles)
            //{
            //    var roleExist = await _roleManager.RoleExistsAsync(role);
            //    if(!roleExist)
            //    {
            //        await _roleManager.CreateAsync(new IdentityRole(role));
            //    }
            //    if(!role.Equals("FundManager") && user!=null)
            //    {
            //        await _userManager.AddToRoleAsync(user, role);
            //    }
            //}
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
