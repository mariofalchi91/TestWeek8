using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework
{
    public class MenuContext:DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Piatto> Piattos { get; set; }
        public DbSet<User> Users { get; set; }
        public MenuContext(DbContextOptions<MenuContext> op): base(op) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // menu

            var mE = mb.Entity<Menu>();
            mE.HasKey(m => m.Id);
            mE.Property(m => m.Nome).IsRequired().HasMaxLength(50);

            // piatti

            var pE = mb.Entity<Piatto>();
            pE.HasKey(p => p.Id);
            pE.Property(p => p.Descrizione).IsRequired().HasMaxLength(50);
            pE.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            pE.Property(p => p.Prezzo).IsRequired();
            pE.Property(p => p.Tipologia).IsRequired();

            // users

            var uE = mb.Entity<User>();
            uE.HasKey(u => u.Id);
            uE.Property(u => u.Email).IsRequired().HasMaxLength(50);
            uE.Property(u => u.Password).IsRequired().HasMaxLength(50);
            uE.Property(u => u.Role).IsRequired();

            // relazione 1 menu ha N piatti

            mE.HasMany(m => m.Piattos).WithOne(p => p.Menu);
            pE.HasOne(p => p.Menu).WithMany(m => m.Piattos).HasForeignKey(p => p.MenuId);

            // aggiungo qualche menu

            mE.HasData(
                new Menu
                {
                    Id = 1,
                    Nome = "Menu di terra"
                },
                new Menu
                {
                    Id = 2,
                    Nome = "Menu di mare"
                }
                );

            // aggiungo qualche piatto

            pE.HasData(
                new Piatto
                {
                    Id = 1,
                    Nome = "Fettuccine coi funghi",
                    Descrizione = "fettuccine buone buone",
                    Tipologia = Tipologia.Primo,
                    Prezzo = 10.50M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 2,
                    Nome = "Fettina di cavallo",
                    Descrizione = "fettina buona buona",
                    Tipologia = Tipologia.Secondo,
                    Prezzo = 12.50M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 3,
                    Nome = "Patate e verdure grigliate",
                    Descrizione = "verdure buone buone",
                    Tipologia = Tipologia.Contorno,
                    Prezzo = 9.50M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 4,
                    Nome = "Crema catalana",
                    Descrizione = "dolcino buono buono",
                    Tipologia = Tipologia.Dolce,
                    Prezzo = 8.50M,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 5,
                    Nome = "Bavette granchi e vongole",
                    Descrizione = "pasta buona buona",
                    Tipologia = Tipologia.Primo,
                    Prezzo = 15.50M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 6,
                    Nome = "Tonno alla piastra",
                    Descrizione = "tonno buono buono",
                    Tipologia = Tipologia.Secondo,
                    Prezzo = 12.50M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 7,
                    Nome = "Cozze aglio prezzemolo e peperoncino",
                    Descrizione = "cozze buone buone",
                    Tipologia = Tipologia.Contorno,
                    Prezzo = 9.50M,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 8,
                    Nome = "Semifreddo al pistacchio",
                    Descrizione = "anche questo buono",
                    Tipologia = Tipologia.Dolce,
                    Prezzo = 8.50M,
                    MenuId = 2
                }
                );

            // aggiungo 2 utenti

            uE.HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@ristorante.it",
                    Password = "0000",
                    Role = Role.Administator
                },
                new User
                {
                    Id = 2,
                    Email = "tiziocaio@ristorante.it",
                    Password = "1234",
                    Role = Role.User
                }
                );
        }
    }
}
