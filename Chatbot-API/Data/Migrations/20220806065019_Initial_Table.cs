using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatbot_API.Data.Migrations
{
    public partial class Initial_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHAT_HISTORIE",
                columns: table => new
                {
                    CHAT_HISTORIE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    IS_COMPLTE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATETIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_DATETIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAT_HISTORIE", x => x.CHAT_HISTORIE_ID);
                });

            migrationBuilder.CreateTable(
                name: "CHAT_HISTORIE_DETAIL",
                columns: table => new
                {
                    CHAT_HISTORIE_DETAIL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHAT_HISTORIE_ID = table.Column<int>(type: "int", nullable: false),
                    MESSAGES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOPICS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_TOPIC = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    TIME_STAMP = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAT_HISTORIE_DETAIL", x => x.CHAT_HISTORIE_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_CHAT_HISTORIE_DETAIL_CHAT_HISTORIE_CHAT_HISTORIE_ID",
                        column: x => x.CHAT_HISTORIE_ID,
                        principalTable: "CHAT_HISTORIE",
                        principalColumn: "CHAT_HISTORIE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_HISTORIE_DETAIL_CHAT_HISTORIE_ID",
                table: "CHAT_HISTORIE_DETAIL",
                column: "CHAT_HISTORIE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHAT_HISTORIE_DETAIL");

            migrationBuilder.DropTable(
                name: "CHAT_HISTORIE");
        }
    }
}
