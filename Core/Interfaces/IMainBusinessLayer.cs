using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        // menu
        IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        bool AddMenu(Menu menu);

        // piatti

        IEnumerable<Piatto> FetchPiattos(Func<Piatto, bool> filter = null);
        Piatto GetPiattoById(int id);
        bool AddPiatto(Piatto piatto);
        bool EditPiatto(Piatto piatto);
        bool DeletePiatto(int id);

        // user

        User GetUserByEmail(string email);
    }
}
