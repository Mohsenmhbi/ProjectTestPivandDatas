using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest.Infrastracture.Migrations
{
    public partial class UserTicket2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CeateDate",
                table: "UserTicket",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "UserTicket",
                newName: "CeateDate");
        }
    }
}
