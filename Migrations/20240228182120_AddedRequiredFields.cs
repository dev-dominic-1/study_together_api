using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace study_together_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequiredFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendUserId",
                table: "Friends",
                column: "FriendUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendUserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendUserId",
                table: "Friends");
        }
    }
}
