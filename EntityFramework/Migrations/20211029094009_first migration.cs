using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piattos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 50, nullable: false),
                    Tipologia = table.Column<int>(nullable: false),
                    Prezzo = table.Column<decimal>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piattos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piattos_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Menu di terra" },
                    { 2, "Menu di mare" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "admin@ristorante.it", "0000", 0 },
                    { 2, "tiziocaio@ristorante.it", "1234", 1 }
                });

            migrationBuilder.InsertData(
                table: "Piattos",
                columns: new[] { "Id", "Descrizione", "MenuId", "Nome", "Prezzo", "Tipologia" },
                values: new object[,]
                {
                    { 1, "fettuccine buone buone", 1, "Fettuccine coi funghi", 10.50m, 0 },
                    { 2, "fettina buona buona", 1, "Fettina di cavallo", 12.50m, 1 },
                    { 3, "verdure buone buone", 1, "Patate e verdure grigliate", 9.50m, 2 },
                    { 4, "dolcino buono buono", 1, "Crema catalana", 8.50m, 3 },
                    { 5, "pasta buona buona", 2, "Bavette granchi e vongole", 15.50m, 0 },
                    { 6, "tonno buono buono", 2, "Tonno alla piastra", 12.50m, 1 },
                    { 7, "cozze buone buone", 2, "Cozze aglio prezzemolo e peperoncino", 9.50m, 2 },
                    { 8, "anche questo buono", 2, "Semifreddo al pistacchio", 8.50m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piattos_MenuId",
                table: "Piattos",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piattos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
