using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot_API.Data.Migrations
{
    public partial class Alter_Tabel_CHAT_HISTORY_DETAIL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BUTTON_ID",
                table: "CHAT_HISTORIE_DETAIL",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUTTON_ID",
                table: "CHAT_HISTORIE_DETAIL");
        }
    }
}
