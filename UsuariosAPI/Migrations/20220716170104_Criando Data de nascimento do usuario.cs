using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class CriandoDatadenascimentodousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "126eeba7-4249-4c00-ad33-b8924a898cdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c328bf16-d05c-437b-8dea-d254b05d3288");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c15762f4-4191-48e0-ab83-59202e315226", "AQAAAAEAACcQAAAAEO4qmwBOwd/q/iHrmybo19hZzG9aMEO514mmIRTfzn3fxtZUNY1wY8xBTxSVTsdKqw==", "2f097e59-0c76-4f5b-ada7-9de7279023bf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "891b382c-bcc1-46d7-afac-405fa4421f37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "34e07d3d-69eb-44bd-9c82-91460a5ce557");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16ca6772-eea4-41ce-8ba8-8c5eae331871", "AQAAAAEAACcQAAAAEO2iwEOmKSX3KEtZAErs6EdxnMQ2U12xIzuqjt3HjXmLN3Hn2D//BjabuGAhv3J42Q==", "d298757c-b45d-473a-94e4-02ae7f5f4199" });
        }
    }
}
