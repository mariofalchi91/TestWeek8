using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;

namespace Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IRepositoryMenu repoMenu;
        private readonly IRepositoryPiatto repoPiatto;
        private readonly IRepositoryUser repoUser;
        public MainBusinessLayer(IRepositoryMenu repositoryMenu, IRepositoryPiatto repositoryPiatto, IRepositoryUser repositoryUser)
        {
            repoMenu = repositoryMenu;
            repoPiatto = repositoryPiatto;
            repoUser = repositoryUser;
        }

        public bool AddMenu(Menu menu)
        {
            if (menu == null)
                return false;
            var res = repoMenu.AddItem(menu);
            if (res == false)
                return false;
            else
                return true;
        }

        public bool AddPiatto(Piatto piatto)
        {
            if (piatto == null)
                return false;
            var res = repoPiatto.AddItem(piatto);
            if (res == false)
                return false;
            else
                return true;
        }

        public bool DeletePiatto(int id)
        {
            if (id <= 0)
                return false;
            var res = repoPiatto.DeleteItem(id);
            if (res == false)
                return false;
            else
                return true;
        }

        public bool EditPiatto(Piatto piatto)
        {
            if (piatto == null)
                return false;
            var res = repoPiatto.UpdateItem(piatto);
            if (res == false)
                return false;
            else
                return true;
        }

        public IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null)
        {
            return repoMenu.Fetch(filter);
        }

        public IEnumerable<Piatto> FetchPiattos(Func<Piatto, bool> filter = null)
        {
            return repoPiatto.Fetch(filter);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            else
                return repoMenu.GetById(id);
        }

        public Piatto GetPiattoById(int id)
        {
            if (id <= 0)
                return null;
            else
                return repoPiatto.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            else
                return repoUser.GetByEmail(email);
        }
    }
}
