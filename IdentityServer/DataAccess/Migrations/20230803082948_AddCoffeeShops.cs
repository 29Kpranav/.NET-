using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddCoffeeShops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO CoffeeShop (Name, OpeningHours, Address) VALUES ('PJ1''s Coffee of New Orleans',               '9-5 Mon-Sat',               '9097 West Locust st. Buffalo, NY 14221')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShop (Name, OpeningHours, Address) VALUES ('PJ2''s Coffee of New Orleans',               '9-5 Mon-Sat',               '9097 West Locust st. Buffalo, NY 14221')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShop (Name, OpeningHours, Address) VALUES ('PJ3''s Coffee of New Orleans',               '9-5 Mon-Sat',               '9097 West Locust st. Buffalo, NY 14221')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShop (Name, OpeningHours, Address) VALUES ('PJ4''s Coffee of New Orleans',               '9-5 Mon-Sat',               '9097 West Locust st. Buffalo, NY 14221')");
            migrationBuilder.Sql($"INSERT INTO CoffeeShop (Name, OpeningHours, Address) VALUES ('PJ5''s Coffee of New Orleans',               '9-5 Mon-Sat',               '9097 West Locust st. Buffalo, NY 14221')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

