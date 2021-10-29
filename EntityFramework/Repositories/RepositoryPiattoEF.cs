using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class RepositoryPiattoEF : IRepositoryPiatto
    {
        private readonly MenuContext c;
        public RepositoryPiattoEF (MenuContext context)
        {
            c = context;
        }
        public bool AddItem(Piatto item)
        {
            if (item == null)
                return false;
            c.Piattos.Add(item);
            c.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;
            var item = c.Piattos.Find(id);
            if (item == null)
                return false;
            c.Piattos.Remove(item);
            c.SaveChanges();
            return true;
        }

        public IEnumerable<Piatto> Fetch(Func<Piatto, bool> filter = null)
        {
            if (filter != null)
                return c.Piattos.Where(filter);
            return c.Piattos;
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                return null;
            return c.Piattos.Find(id);
        }

        public bool UpdateItem(Piatto item)
        {
            if (item == null)
                return false;
            c.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            c.SaveChanges();
            return true;
        }
    }
}
