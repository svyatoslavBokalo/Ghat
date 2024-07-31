using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ldis_Project_Reliz.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreatepropertyAutodeletingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoDeletingUser",
                table: "Chats",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoDeletingUser",
                table: "Chats");
        }
    }
}
