using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot_API.Data.Migrations
{
    public partial class Alter_Tabel_CHAT_HISTORY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "USER_TYPE",
                table: "CHAT_HISTORIE",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USER_TYPE",
                table: "CHAT_HISTORIE");
        }
    }
}
