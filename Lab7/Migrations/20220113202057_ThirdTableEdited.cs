using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab7.Migrations
{
    public partial class ThirdTableEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drive_Pcs_PcId",
                table: "Drive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drive",
                table: "Drive");

            migrationBuilder.RenameTable(
                name: "Drive",
                newName: "Drives");

            migrationBuilder.RenameIndex(
                name: "IX_Drive_PcId",
                table: "Drives",
                newName: "IX_Drives_PcId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drives",
                table: "Drives",
                column: "DriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Pcs_PcId",
                table: "Drives",
                column: "PcId",
                principalTable: "Pcs",
                principalColumn: "PcId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Pcs_PcId",
                table: "Drives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drives",
                table: "Drives");

            migrationBuilder.RenameTable(
                name: "Drives",
                newName: "Drive");

            migrationBuilder.RenameIndex(
                name: "IX_Drives_PcId",
                table: "Drive",
                newName: "IX_Drive_PcId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drive",
                table: "Drive",
                column: "DriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drive_Pcs_PcId",
                table: "Drive",
                column: "PcId",
                principalTable: "Pcs",
                principalColumn: "PcId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
