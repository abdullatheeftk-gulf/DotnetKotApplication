using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetKotApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_Name",
                table: "Products",
                newName: "IX_Products_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Name",
                table: "MyProperty",
                newName: "IX_MyProperty_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
