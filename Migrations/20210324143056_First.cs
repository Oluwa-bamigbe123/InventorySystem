using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Agents",
                maxLength: 72,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Agents",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 72);
        }
    }
}
