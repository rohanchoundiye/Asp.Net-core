using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.MyDatabase
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightBookingDetail",
                columns: table => new
                {
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfJourney = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookingDetail", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FlightAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableTickets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.FlightId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightBookingDetail");

            migrationBuilder.DropTable(
                name: "FlightDetails");
        }
    }
}
