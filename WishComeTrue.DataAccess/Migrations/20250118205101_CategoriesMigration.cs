using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishComeTrue.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Wishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_CategoryId",
                table: "Wishes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishes_Categories_CategoryId",
                table: "Wishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishes_Categories_CategoryId",
                table: "Wishes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Wishes_CategoryId",
                table: "Wishes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Wishes");
        }
    }
}
