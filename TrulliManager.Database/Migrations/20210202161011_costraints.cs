using Microsoft.EntityFrameworkCore.Migrations;

namespace TrulliManager.Database.Migrations
{
    public partial class costraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trullo",
                table: "Trullo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Trullo",
                newName: "Trulli");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Trulli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trulli",
                table: "Trulli",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trulli_PropertyId",
                table: "Trulli",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trulli_Properties_PropertyId",
                table: "Trulli",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trulli_Properties_PropertyId",
                table: "Trulli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trulli",
                table: "Trulli");

            migrationBuilder.DropIndex(
                name: "IX_Trulli_PropertyId",
                table: "Trulli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Trulli");

            migrationBuilder.RenameTable(
                name: "Trulli",
                newName: "Trullo");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trullo",
                table: "Trullo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");
        }
    }
}
