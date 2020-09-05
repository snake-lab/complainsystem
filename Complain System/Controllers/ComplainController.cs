using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Complain_System.Controllers
{
    public class ComplainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
