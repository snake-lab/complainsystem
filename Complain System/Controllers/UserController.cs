using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compain_System.Shared;
using Complain_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Complain_System.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ComplainDbContext context;

        string role1 = "student";
        string role2 = "coordinator";
        string role3 = "teacher";

        public UserController(UserManager<AppUser> _userManager,SignInManager<AppUser> _signInManager,RoleManager<AppRole> _roleManager, ComplainDbContext _context){
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CoordinatorRegisterViewModel model)
        {
            //TODO: Make user registration 
            if (ModelState.IsValid)
            {
                
                // Copy data from RegisterViewModel to IdentityUser
                var user = new AppUser
                {
                    Email = model.Email,
                    FullName = model.FullName,
                    Mobile = model.Mobile

                };
                var employee = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    EmployeeName = model.FullName,
                    EmployeeRole = role2
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);
                context.Add(employee);
                await context.SaveChangesAsync();
                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, isPersistent: false);
                    if (await roleManager.FindByNameAsync(role2) == null)
                    {
                        await roleManager.CreateAsync(new AppRole(role2));
                    }
                    await userManager.AddToRoleAsync(user, role2);

                    return RedirectToAction("index", "home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
