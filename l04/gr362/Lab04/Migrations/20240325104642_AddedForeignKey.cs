using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab04.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stire_Categorie_CategorieId",
                table: "Stire");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Stire",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Stire",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stire_Categorie_CategorieId",
                table: "Stire",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }
    }
}
