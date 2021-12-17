using Microsoft.EntityFrameworkCore.Migrations;

namespace WithoutBorders.Data.SqlServer.Migrations
{
    public partial class tweekerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8cb4b8b6-cf30-4668-8d7f-263172c1c605");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8af352d1-ed5e-42b4-8813-d70b37e0fc80", "AQAAAAEAACcQAAAAEIs8Q5qwGVUwx9sIXz7aXouQuQhgLJqU3LGBNuQN+6mXvh+L8/qNyEQs1REp8CnhhA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fb1f883d-8fad-41c9-b170-7b1c617fe2db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bcd05323-1bc2-4968-a468-c8bf7c73ef26", "AQAAAAEAACcQAAAAELiKoHo9em7iGIPe6iBYxm3HqI9WchzktlnvMGjTdnKF81CzsUFnF/l2pRphBg4jCA==" });
        }
    }
}
