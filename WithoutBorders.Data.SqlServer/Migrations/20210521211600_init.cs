using Microsoft.EntityFrameworkCore.Migrations;

namespace WithoutBorders.Data.SqlServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5d306d3e-1408-4a9c-a7cf-2e5bf39fb7c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "382095d0-244f-49f8-93ac-27a5fa2b47ee", "AQAAAAEAACcQAAAAEDW+uKT7UvbYlzrm6lOmAidt3x8G5A10FIuWU5zomrygHArX2arj6E8KuciTzfk4Tw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "429f1d11-4c1d-4c4b-9016-cd6447a40a32", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENQPTSAuJcveo9W8CSBgip74Uk+qYBKUPGstpF4aaEIjX72aiMvYZa4X63W7X7/nNg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fa9e5302-d6db-4875-b873-dab27ae6ea1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c686daa0-7477-4d9f-9d50-9b1c6bf86a34", "AQAAAAEAACcQAAAAEFZIRu9vm95dslTq5DIoO3rqNr8cGNNisouEK1pclfHXRwPQNpc6srk5Wg85Hp7VBw==" });
        }
    }
}
