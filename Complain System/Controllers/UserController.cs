using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compain_System.Shared;
using Complain_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Complain_System.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ComplainDbContext context;
        private readonly ILogger<UserController> logger;

        readonly string role1 = "student";
        readonly string role2 = "coordinator";
        readonly string role3 = "teacher";

        public UserController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, ComplainDbContext _context, ILogger<UserController> _logger)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            context = _context;
            logger = _logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        //HTTP GET
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
                    Mobile = model.Mobile,
                    UserName = model.Email
                };
                var employee = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    EmployeeName = model.FullName,
                    EmployeeRole = role2
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // Stores data in employee table
                context.Add(employee);
                await context.SaveChangesAsync();
                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    // Automatic signin 
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //if the use has no role, give them Coordinator Role.
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

        public async Task<IActionResult> StudentRegister(CoordinatorRegisterViewModel model)
        {
            //TODO: Make user registration 
            if (ModelState.IsValid)
            {

                // Copy data from RegisterViewModel to IdentityUser
                var user = new AppUser
                {
                    Email = model.Email,
                    FullName = model.FullName,
                    Mobile = model.Mobile,
                    UserName = model.Email
                };
                var employee = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    EmployeeName = model.FullName,
                    EmployeeRole = role1
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // Stores data in employee table
                context.Add(employee);
                await context.SaveChangesAsync();
                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    // Automatic signin 
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //if the use has no role, give them Coordinator Role.
                    if (await roleManager.FindByNameAsync(role1) == null)
                    {
                        await roleManager.CreateAsync(new AppRole(role1));
                    }
                    await userManager.AddToRoleAsync(user, role1);

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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Input)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");

                    // Login is successful here, so we return now and the execution stops, meaning the bottom code never runs.
                    return RedirectToAction("index", "home");
                }
            }

            // If we get to this line, either the MoxelState isn't valid or the login failed.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

    }
}
