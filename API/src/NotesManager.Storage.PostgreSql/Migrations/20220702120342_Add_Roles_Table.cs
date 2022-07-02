using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotesManager.Storage.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Add_Roles_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "notes",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "notes",
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Имеет расширенные права в рамках системы", "Admin" },
                    { 2, "Имеет ограниченный набор прав в рамках системы", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "notes",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "notes",
                table: "Users",
                column: "RoleId",
                principalSchema: "notes",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "notes",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "notes");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                schema: "notes",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "notes",
                table: "Users");
        }
    }
}
