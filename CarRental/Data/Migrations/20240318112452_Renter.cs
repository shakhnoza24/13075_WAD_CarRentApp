using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Data.Migrations
{
    public partial class Renter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Renters_RenterId",
                table: "Cars",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Renters_RenterId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RenterId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Cars");
        }
    }
}
