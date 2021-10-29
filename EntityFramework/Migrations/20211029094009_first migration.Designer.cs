﻿// <auto-generated />
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20211029094009_first migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Menu di terra"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Menu di mare"
                        });
                });

            modelBuilder.Entity("Core.Models.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipologia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Piattos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "fettuccine buone buone",
                            MenuId = 1,
                            Nome = "Fettuccine coi funghi",
                            Prezzo = 10.50m,
                            Tipologia = 0
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "fettina buona buona",
                            MenuId = 1,
                            Nome = "Fettina di cavallo",
                            Prezzo = 12.50m,
                            Tipologia = 1
                        },
                        new
                        {
                            Id = 3,
                            Descrizione = "verdure buone buone",
                            MenuId = 1,
                            Nome = "Patate e verdure grigliate",
                            Prezzo = 9.50m,
                            Tipologia = 2
                        },
                        new
                        {
                            Id = 4,
                            Descrizione = "dolcino buono buono",
                            MenuId = 1,
                            Nome = "Crema catalana",
                            Prezzo = 8.50m,
                            Tipologia = 3
                        },
                        new
                        {
                            Id = 5,
                            Descrizione = "pasta buona buona",
                            MenuId = 2,
                            Nome = "Bavette granchi e vongole",
                            Prezzo = 15.50m,
                            Tipologia = 0
                        },
                        new
                        {
                            Id = 6,
                            Descrizione = "tonno buono buono",
                            MenuId = 2,
                            Nome = "Tonno alla piastra",
                            Prezzo = 12.50m,
                            Tipologia = 1
                        },
                        new
                        {
                            Id = 7,
                            Descrizione = "cozze buone buone",
                            MenuId = 2,
                            Nome = "Cozze aglio prezzemolo e peperoncino",
                            Prezzo = 9.50m,
                            Tipologia = 2
                        },
                        new
                        {
                            Id = 8,
                            Descrizione = "anche questo buono",
                            MenuId = 2,
                            Nome = "Semifreddo al pistacchio",
                            Prezzo = 8.50m,
                            Tipologia = 3
                        });
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@ristorante.it",
                            Password = "0000",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "tiziocaio@ristorante.it",
                            Password = "1234",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Core.Models.Piatto", b =>
                {
                    b.HasOne("Core.Models.Menu", "Menu")
                        .WithMany("Piattos")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
