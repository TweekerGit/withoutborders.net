using Microsoft.EntityFrameworkCore.Migrations;

namespace WithoutBorders.Data.SqlServer.Migrations
{
    public partial class selectedMainAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedMains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedMains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedMains_MainEntities_MainId",
                        column: x => x.MainId,
                        principalTable: "MainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d66906e6-8cd4-4a43-9779-9433c367d304");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6c301a2-8d82-4ca9-895c-affdca593ea5", "AQAAAAEAACcQAAAAEJ/u/DRFRem+vio0Y+jyWQmXzB1Md99vzTFzWwf2tWWC6aoWxgq1xQS48Gbuywwncw==" });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedMains_MainId",
                table: "SelectedMains",
                column: "MainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedMains");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c749781c-96ca-4491-8007-0b5d9c5f6101");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70c71485-b92d-4e52-94c8-8853b7f0bb47", "AQAAAAEAACcQAAAAENzmYqyb7LxzCY1iteIn2F4WTtmjRblToKLDA/hM2VELVBMUk51M+89vo/KSNQUrbQ==" });
        }
    }
}
