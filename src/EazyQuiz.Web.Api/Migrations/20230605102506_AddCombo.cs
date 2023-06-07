using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EazyQuiz.Web.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxCombo",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90fa1d46-da3d-4cb1-b36d-8008c7f628c2"),
                column: "MaxCombo",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCombo",
                table: "Users");
        }
    }
}
