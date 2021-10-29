using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBl;
        public MenuController(IMainBusinessLayer bl)
        {
            mainBl = bl;
        }

        public IActionResult Index()
        {
            var result = mainBl.FetchMenus();
            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }

        public IActionResult Detail(int code)
        {
            if (code <= 0)
                return View("ExceptionError");

            //var menu = mainBl.GetMenuById(code);
            //if (menu == null)
            //    return View("NotFound");
            //var resultMapped = menu.ToViewModel();

            var piatti = mainBl.FetchPiattos(p => p.MenuId == code);
            var piattiMappati = piatti.ToListViewModel();

            return View(piattiMappati);
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model == null)
                return View("ExceptionError", false);

            Menu newMenu = model.ToMenu();
            var result = mainBl.AddMenu(newMenu);
            if (result == false)
                return View("ExceptionError", false);

            return RedirectToAction(nameof(Index));
        }
    }
}
