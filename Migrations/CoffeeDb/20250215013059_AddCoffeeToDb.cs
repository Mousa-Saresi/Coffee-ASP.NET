using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_Shop2.Migrations.CoffeeDb
{
    /// <inheritdoc />
    public partial class AddCoffeeToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeShope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Person = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeShope", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeShope");
        }
    }
}
