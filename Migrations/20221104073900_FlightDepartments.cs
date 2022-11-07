using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreRelationships.Migrations
{
    public partial class FlightDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightDepartmentsTickets",
                columns: table => new
                {
                    FlightDepartmentsId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDepartmentsTickets", x => new { x.FlightDepartmentsId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_FlightDepartmentsTickets_FlightDepartments_FlightDepartmentsId",
                        column: x => x.FlightDepartmentsId,
                        principalTable: "FlightDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightDepartmentsTickets_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartmentsTickets_TicketsId",
                table: "FlightDepartmentsTickets",
                column: "TicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightDepartmentsTickets");

            migrationBuilder.DropTable(
                name: "FlightDepartments");
        }
    }
}
