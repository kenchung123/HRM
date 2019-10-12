using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Model.Migrations
{
    public partial class addNewProjectMerge : Migration
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
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    NameRequest = table.Column<string>(nullable: true),
                    Percent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_Shift", x => x.Id);
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
                    FactoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Password = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
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
                    Flags = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => new { x.Id, x.ShiftId });
                    table.UniqueConstraint("AK_EmployeeShift_Id", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeOff",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    Sender = table.Column<Guid>(nullable: false),
                    Receiver = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    IsAllDay = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeOff_Employee_Receiver",
                        column: x => x.Receiver,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeOff_Employee_Sender",
                        column: x => x.Sender,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SendById = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    UnitFrom = table.Column<Guid>(nullable: false),
                    UnitTo = table.Column<Guid>(nullable: false),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferWork_Employee_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferWork_Employee_SendById",
                        column: x => x.SendById,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferWork_Unit_UnitFrom",
                        column: x => x.UnitFrom,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferWork_Unit_UnitTo",
                        column: x => x.UnitTo,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApproveDayOff",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Flags = table.Column<int>(nullable: true),
                    TimeOffId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    RequestTypeId = table.Column<Guid>(nullable: false),
                    ApproverId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproveDayOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApproveDayOff_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApproveDayOff_TimeOff_TimeOffId",
                        column: x => x.TimeOffId,
                        principalTable: "TimeOff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApproveDayOff_RequestTypeId",
                table: "ApproveDayOff",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApproveDayOff_TimeOffId",
                table: "ApproveDayOff",
                column: "TimeOffId",
                unique: true);

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
                name: "IX_TimeOff_Receiver",
                table: "TimeOff",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOff_Sender",
                table: "TimeOff",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_TransferWork_ReceiverId",
                table: "TransferWork",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferWork_SendById",
                table: "TransferWork",
                column: "SendById");

            migrationBuilder.CreateIndex(
                name: "IX_TransferWork_UnitFrom",
                table: "TransferWork",
                column: "UnitFrom");

            migrationBuilder.CreateIndex(
                name: "IX_TransferWork_UnitTo",
                table: "TransferWork",
                column: "UnitTo");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_FactoryId",
                table: "Unit",
                column: "FactoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApproveDayOff");

            migrationBuilder.DropTable(
                name: "ChangeShift");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "TransferWork");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "TimeOff");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Factory");
        }
    }
}
