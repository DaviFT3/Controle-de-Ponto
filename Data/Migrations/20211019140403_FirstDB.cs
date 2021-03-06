using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(100)", nullable: false),
                    CorporateName = table.Column<string>(name: "Corporate Name", type: "varchar(100)", nullable: false),
                    Project = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", nullable: false),
                    Vacations = table.Column<bool>(type: "varchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "varchar(100)", nullable: false),
                    Assignment = table.Column<string>(type: "varchar(100)", nullable: false),
                    HiringType = table.Column<string>(name: "Hiring Type", type: "varchar(100)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "DayOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    DayOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOffs_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DayOffs_User_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryTime = table.Column<DateTime>(name: "Entry Time", type: "varchar(100)", nullable: false),
                    LunchTime = table.Column<DateTime>(name: "Lunch Time", type: "varchar(100)", nullable: false),
                    LunchReturnTime = table.Column<DateTime>(name: "Lunch Return Time", type: "varchar(100)", nullable: false),
                    DepartureTime = table.Column<DateTime>(name: "Departure Time", type: "varchar(100)", nullable: false),
                    WorkedHours = table.Column<double>(name: "Worked Hours", type: "varchar(100)", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_User_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_CollaboratorId",
                table: "Dashboard",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffs_CollaboratorId",
                table: "DayOffs",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffs_CompanyId",
                table: "DayOffs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CollaboratorId",
                table: "Schedule",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dashboard");

            migrationBuilder.DropTable(
                name: "DayOffs");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
