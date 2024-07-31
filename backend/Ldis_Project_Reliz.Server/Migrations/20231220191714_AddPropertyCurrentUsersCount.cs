using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ldis_Project_Reliz.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyCurrentUsersCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCountUsers",
                table: "Chats",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCountUsers",
                table: "Chats");
        }
    }
}
