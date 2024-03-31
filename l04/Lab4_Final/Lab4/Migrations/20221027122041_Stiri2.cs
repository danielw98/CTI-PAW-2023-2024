using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.Migrations
{
    public partial class Stiri2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Stire");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Stire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stire_CategorieId",
                table: "Stire",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stire_Categorie_CategorieId",
                table: "Stire",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stire_Categorie_CategorieId",
                table: "Stire");

            migrationBuilder.DropIndex(
                name: "IX_Stire_CategorieId",
                table: "Stire");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Stire");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Stire",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
