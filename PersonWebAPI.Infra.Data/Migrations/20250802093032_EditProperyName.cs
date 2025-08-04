using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonWebAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditProperyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Persons",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groups",
                newName: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Persons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Groups",
                newName: "Id");
        }
    }
}
