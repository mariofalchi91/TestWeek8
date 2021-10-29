using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IMainBusinessLayer mainBl;
        public PiattiController(IMainBusinessLayer bl)
        {
            mainBl = bl;
        }
        public IActionResult Index()
        {
            var result = mainBl.FetchPiattos();
            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }
    }
}
