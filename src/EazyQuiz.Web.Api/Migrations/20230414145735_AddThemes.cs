using Microsoft.EntityFrameworkCore.Migrations;


namespace EazyQuiz.Web.Api.Migrations
{
    public partial class AddThemes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03009ee9-c62d-4340-9106-59177d3dff8f"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThemeId",
                table: "Questions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "Gender", "PasswordHash", "PasswordSalt", "Points", "RegistrationTime", "Username" },
                values: new object[] { new Guid("90fa1d46-da3d-4cb1-b36d-8008c7f628c2"), 0, "", "", "H3rq06vpbbJMWds6JlG4BeH4egt3bEm/wVUdqpwBqyBDjSxbB+PHUp9vb/gdM6B4wqql3B/FU888P7GQ9nXDag==", "ELiNWv7oU1w/a4Wph9boQGdnx2ADiSF9Q0WUI5C0od4=", 0, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Dev" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ThemeId",
                table: "Questions",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Themes_ThemeId",
                table: "Questions",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Themes_ThemeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ThemeId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90fa1d46-da3d-4cb1-b36d-8008c7f628c2"));

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "Gender", "PasswordHash", "PasswordSalt", "Points", "RegistrationTime", "Username" },
                values: new object[] { new Guid("03009ee9-c62d-4340-9106-59177d3dff8f"), 0, "", "", "H3rq06vpbbJMWds6JlG4BeH4egt3bEm/wVUdqpwBqyBDjSxbB+PHUp9vb/gdM6B4wqql3B/FU888P7GQ9nXDag==", "ELiNWv7oU1w/a4Wph9boQGdnx2ADiSF9Q0WUI5C0od4=", 0, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Dev" });
        }
    }
}
