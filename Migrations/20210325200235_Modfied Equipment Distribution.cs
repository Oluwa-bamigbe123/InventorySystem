using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class ModfiedEquipmentDistribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentGeneratedKey",
                table: "EquipmentDistribution");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentGeneratedKey",
                table: "EquipmentDistribution",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
