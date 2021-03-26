using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class ModifyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "EquipmentDistribution",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
