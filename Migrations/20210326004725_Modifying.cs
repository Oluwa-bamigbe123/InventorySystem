using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class Modifying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "EquipmentDistribution",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "EquipmentDistribution",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "EquipmentDistribution",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Managers_ManagerId",
                table: "EquipmentDistribution",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
