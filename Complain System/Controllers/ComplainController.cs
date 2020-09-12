using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compain_System.Shared;
using Complain_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Complain_System.Controllers
{
    public class ComplainController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ComplainDbContext context;
        private readonly ILogger<ComplainController> logger;
        public ComplainController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, ComplainDbContext _context, ILogger<UserController> _logger)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateComplain()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComplain(ComplainboxViewModel model)
        {

            if (ModelState.IsValid)
            {
                var complain = new ComplainBox()
                {

                };
                try
                {
                    context.Add(complain);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
        }
    }
}
