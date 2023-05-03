using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EazyQuiz.Web.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndRemoveAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RegistrationTime",
                table: "Users",
                newName: "LastActiveTime");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "Role");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90fa1d46-da3d-4cb1-b36d-8008c7f628c2"),
                column: "Role",
                value: "Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "LastActiveTime",
                table: "Users",
                newName: "RegistrationTime");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90fa1d46-da3d-4cb1-b36d-8008c7f628c2"),
                columns: new[] { "Age", "Gender" },
                values: new object[] { 0, "" });
        }
    }
}
