using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab04.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stiri_Categorie_CategorieId",
                table: "Stiri");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Stiri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stiri_Categorie_CategorieId",
                table: "Stiri",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stiri_Categorie_CategorieId",
                table: "Stiri");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Stiri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stiri_Categorie_CategorieId",
                table: "Stiri",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }
    }
}
