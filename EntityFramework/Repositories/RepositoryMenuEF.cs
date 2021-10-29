using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly MenuContext c;
        public RepositoryMenuEF (MenuContext context)
        {
            c = context;
        }
        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;
            c.Menus.Add(item);
            c.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            return false;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return c.Menus.Where(filter);
            return c.Menus;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return c.Menus.Find(id);
        }

        public bool UpdateItem(Menu item)
        {
            return false;
        }
    }
}
