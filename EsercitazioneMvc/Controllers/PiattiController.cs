using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class PiattiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
