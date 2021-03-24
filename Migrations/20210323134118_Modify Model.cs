using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class ModifyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentGenereatedKey",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentGeneratedKey",
                table: "EquipmentDistribution",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentGeneratedKey",
                table: "EquipmentDistribution");

            migrationBuilder.AddColumn<string>(
                name: "EquipmentGenereatedKey",
                table: "Equipments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
