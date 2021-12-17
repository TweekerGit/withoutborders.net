using Microsoft.EntityFrameworkCore.Migrations;

namespace WithoutBorders.Data.SqlServer.Migrations
{
    public partial class tweekerUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "407a0300-edea-4a25-83b8-ab2bebf92561");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7cbbfa92-63a8-4492-a2ba-eafded6448ba", "TWEEKER", "AQAAAAEAACcQAAAAEJjKzVAZGguQDXKfWl+PlEJTEk5wsC1MIs2/LTPwnzA2D8pg9KcxrzEpViCaMzBRLA==", "tweeker" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "8af352d1-ed5e-42b4-8813-d70b37e0fc80", "ADMIN", "AQAAAAEAACcQAAAAEIs8Q5qwGVUwx9sIXz7aXouQuQhgLJqU3LGBNuQN+6mXvh+L8/qNyEQs1REp8CnhhA==", "admin" });
        }
    }
}
