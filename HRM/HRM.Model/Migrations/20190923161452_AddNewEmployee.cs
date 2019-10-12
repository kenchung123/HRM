using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Model.Migrations
{
    public partial class AddNewEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    Sender = table.Column<string>(nullable: false),
                    Receiver = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    FactoryName = table.Column<string>(nullable: false),
                    UnitName = table.Column<string>(nullable: false),
                    OldShift = table.Column<string>(nullable: false),
                    NewShift = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    PositionName = table.Column<string>(maxLength: 30, nullable: false),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    ShiftName = table.Column<string>(maxLength: 30, nullable: false),
                    Marks = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                    table.UniqueConstraint("AK_Shift_Id_ShiftId", x => new { x.Id, x.ShiftId });
                });

            migrationBuilder.CreateTable(
                name: "TimeOff",
                columns: table => new
                {
                    TimeOffId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    Sender = table.Column<string>(nullable: false),
                    Receiver = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    IsAllDay = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOff", x => x.TimeOffId);
                    table.UniqueConstraint("AK_TimeOff_Id_TimeOffId", x => new { x.Id, x.TimeOffId });
                });

            migrationBuilder.CreateTable(
                name: "TransferWork",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    UnitFrom = table.Column<Guid>(nullable: false),
                    UnitTo = table.Column<Guid>(nullable: false),
                    Appprover = table.Column<Guid>(nullable: false),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CostAccountNumber = table.Column<string>(nullable: true),
                    FactoryId = table.Column<string>(nullable: true),
                    FactoryId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Factory_FactoryId1",
                        column: x => x.FactoryId1,
                        principalTable: "Factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    HireDay = table.Column<DateTime>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    BasicSalary = table.Column<int>(nullable: false),
                    Coefficient = table.Column<decimal>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false),
                    IsManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShiftId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => new { x.Id, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Employee_Id",
                        column: x => x.Id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UnitId",
                table: "Employee",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftId",
                table: "EmployeeShift",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FactoryId1",
                table: "Unit",
                column: "FactoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeShift");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "TimeOff");

            migrationBuilder.DropTable(
                name: "TransferWork");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Factory");
        }
    }
}
