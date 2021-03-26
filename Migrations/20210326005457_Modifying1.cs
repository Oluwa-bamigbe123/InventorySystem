using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class Modifying1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Equipments_EquipmentsId",
                table: "EquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                table: "EquipmentDistribution",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Equipments_EquipmentsId",
                table: "EquipmentDistribution",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Equipments_EquipmentsId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Equipments_EquipmentsId",
                table: "EquipmentDistribution",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
