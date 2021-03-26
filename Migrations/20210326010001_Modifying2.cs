using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class Modifying2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentUserName",
                table: "EquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentName",
                table: "EquipmentDistribution");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentUserName",
                table: "EquipmentDistribution",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EquipmentName",
                table: "EquipmentDistribution",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
