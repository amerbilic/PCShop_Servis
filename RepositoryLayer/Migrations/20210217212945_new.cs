using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZaposlenikId",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumPokusaja",
                value: new DateTime(2021, 2, 17, 22, 29, 44, 664, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Popusti",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumDo", "DatumOd" },
                values: new object[] { new DateTime(2021, 2, 17, 22, 29, 44, 664, DateTimeKind.Local).AddTicks(1511), new DateTime(2021, 2, 17, 22, 29, 44, 661, DateTimeKind.Local).AddTicks(6621) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZaposlenikId",
                table: "Narudzba",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kupci",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumPokusaja",
                value: new DateTime(2021, 2, 17, 17, 56, 35, 487, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Popusti",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatumDo", "DatumOd" },
                values: new object[] { new DateTime(2021, 2, 17, 17, 56, 35, 487, DateTimeKind.Local).AddTicks(4953), new DateTime(2021, 2, 17, 17, 56, 35, 485, DateTimeKind.Local).AddTicks(336) });
        }
    }
}
