using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseBroker.Migrations
{
    /// <inheritdoc />
    public partial class author_remove_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_users_user_id",
                schema: "learning",
                table: "authors");

            migrationBuilder.DropIndex(
                name: "IX_authors_user_id",
                schema: "learning",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "learning",
                table: "authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "user_id",
                schema: "learning",
                table: "authors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_authors_user_id",
                schema: "learning",
                table: "authors",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_users_user_id",
                schema: "learning",
                table: "authors",
                column: "user_id",
                principalSchema: "auth",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
