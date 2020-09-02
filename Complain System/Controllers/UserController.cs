using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compain_System.Shared;
namespace Complain_System.Controllers
{
    public class UserController : Controller
    {
        
        public UserController(){

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
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MemberID = model.MemberID

                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, isPersistent: false);
                    if (await roleManager.FindByNameAsync(role2) == null)
                    {
                        await roleManager.CreateAsync(new ApplicationRole(role2));
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
