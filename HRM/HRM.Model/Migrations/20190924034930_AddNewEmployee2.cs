using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Model.Migrations
{
    public partial class AddNewEmployee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Factory_FactoryId1",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_FactoryId1",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "FactoryId1",
                table: "Unit");

            migrationBuilder.AlterColumn<Guid>(
                name: "FactoryId",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FactoryId",
                table: "Unit",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Factory_FactoryId",
                table: "Unit",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Factory_FactoryId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_FactoryId",
                table: "Unit");

            migrationBuilder.AlterColumn<string>(
                name: "FactoryId",
                table: "Unit",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "FactoryId1",
                table: "Unit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FactoryId1",
                table: "Unit",
                column: "FactoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Factory_FactoryId1",
                table: "Unit",
                column: "FactoryId1",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
