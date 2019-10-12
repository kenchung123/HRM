using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Model.Migrations
{
    public partial class updateMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShift_Employee_Id",
                table: "EmployeeShift");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeId",
                table: "EmployeeShift",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShift_Employee_EmployeeId",
                table: "EmployeeShift",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShift_Employee_EmployeeId",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_EmployeeId",
                table: "EmployeeShift");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShift_Employee_Id",
                table: "EmployeeShift",
                column: "Id",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
