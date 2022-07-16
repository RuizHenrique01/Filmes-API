using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class CriandoRoleRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "34e07d3d-69eb-44bd-9c82-91460a5ce557");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "891b382c-bcc1-46d7-afac-405fa4421f37", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16ca6772-eea4-41ce-8ba8-8c5eae331871", "AQAAAAEAACcQAAAAEO2iwEOmKSX3KEtZAErs6EdxnMQ2U12xIzuqjt3HjXmLN3Hn2D//BjabuGAhv3J42Q==", "d298757c-b45d-473a-94e4-02ae7f5f4199" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "44952228-0c24-4e1e-b6e3-0899f747cf8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba3b5618-bbb0-4845-9099-dfd9d62bcc3d", "AQAAAAEAACcQAAAAEIXCvUDHR15bLjNKHsYyXkFTE19HBP78iG44Qf91SS1V7GLSS8ey8un0gLncZThO9g==", "e85b5599-b1b8-493c-a897-3d8f2cd3a972" });
        }
    }
}
