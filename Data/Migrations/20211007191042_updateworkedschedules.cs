using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateworkedschedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Worked Hours",
                table: "Schedule",
                type: "varchar(100)",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Worked Hours",
                table: "Schedule",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "varchar(100)");
        }
    }
}
