using Core.Models;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc
{
    public static class MappingExtensions
    {
        public static MenuViewModel ToViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome
            };
        }

        public static IEnumerable<MenuViewModel> ToListViewModel(this IEnumerable<Menu> menu)
        {
            return menu.Select(m => m.ToViewModel());
        }

        public static IEnumerable<PiattoViewModel> ToListViewModel(this IEnumerable<Piatto> piatto)
        {
            return piatto.Select(p => p.ToViewModel());
        }

        public static PiattoViewModel ToViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia=(Models.Tipologia)piatto.Tipologia,
                Prezzo=piatto.Prezzo,
                MenuId=piatto.MenuId
            };
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome
            };
        }
    }
}
