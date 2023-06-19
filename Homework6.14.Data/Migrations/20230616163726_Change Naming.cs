using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._14.Data.Migrations
{
    public partial class ChangeNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_IncomeSources_IncomeSourceId",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeSources",
                table: "IncomeSources");

            migrationBuilder.RenameTable(
                name: "IncomeSources",
                newName: "Sources");

            migrationBuilder.RenameColumn(
                name: "IncomeSourceId",
                table: "Incomes",
                newName: "SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_IncomeSourceId",
                table: "Incomes",
                newName: "IX_Incomes_SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sources",
                table: "Sources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Sources_SourceId",
                table: "Incomes",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Sources_SourceId",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sources",
                table: "Sources");

            migrationBuilder.RenameTable(
                name: "Sources",
                newName: "IncomeSources");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Incomes",
                newName: "IncomeSourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_SourceId",
                table: "Incomes",
                newName: "IX_Incomes_IncomeSourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeSources",
                table: "IncomeSources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_IncomeSources_IncomeSourceId",
                table: "Incomes",
                column: "IncomeSourceId",
                principalTable: "IncomeSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
