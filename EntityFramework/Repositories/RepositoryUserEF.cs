using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class RepositoryUserEF : IRepositoryUser
    {
        private readonly MenuContext c;
        public RepositoryUserEF(MenuContext context)
        {
            c = context;
        }
        public bool AddItem(User item)
        {
            return false;
        }

        public bool DeleteItem(int id)
        {
            return false;
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            return null;
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return c.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            return null;
        }

        public bool UpdateItem(User item)
        {
            return false;
        }
    }
}
