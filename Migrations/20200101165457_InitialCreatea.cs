using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_de_catalogue.Migrations
{
    public partial class InitialCreatea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "PRODUITS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomCategorie = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CategorieID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUITS_CategorieID",
                table: "PRODUITS",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUITS_CATEGORIES_CategorieID",
                table: "PRODUITS",
                column: "CategorieID",
                principalTable: "CATEGORIES",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUITS_CATEGORIES_CategorieID",
                table: "PRODUITS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropIndex(
                name: "IX_PRODUITS_CategorieID",
                table: "PRODUITS");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "PRODUITS");
        }
    }
}
