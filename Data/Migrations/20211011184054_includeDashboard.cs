using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class includeDashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    HoursBalance = table.Column<double>(name: "Hours Balance", type: "varchar(100)", nullable: false),
                    Workload = table.Column<double>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dashboard_User_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_CollaboratorId",
                table: "Dashboard",
                column: "CollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dashboard");
        }
    }
}
