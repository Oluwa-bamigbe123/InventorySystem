using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class ModifiedDistributionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "EquipmentDistribution",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgentUserName",
                table: "EquipmentDistribution",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentName",
                table: "EquipmentDistribution",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "AgentUserName",
                table: "EquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentName",
                table: "EquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "EquipmentDistribution",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDistribution_Agents_AgentId",
                table: "EquipmentDistribution",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
