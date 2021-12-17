using Microsoft.EntityFrameworkCore.Migrations;

namespace WithoutBorders.Data.SqlServer.Migrations
{
    public partial class MainEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftTitlePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightTitlePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expectation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expression = table.Column<int>(type: "int", nullable: false),
                    MainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expectation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expectation_MainEntities_MainId",
                        column: x => x.MainId,
                        principalTable: "MainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expectation_MainId",
                table: "Expectation",
                column: "MainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expectation");

            migrationBuilder.DropTable(
                name: "MainEntities");
        }
    }
}
