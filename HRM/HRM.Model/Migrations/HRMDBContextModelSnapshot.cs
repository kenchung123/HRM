﻿// <auto-generated />
using System;
using HRM.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRM.Model.Migrations
{
    [DbContext(typeof(HRMDBContext))]
    partial class HRMDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRM.Model.Entities.EmployeeShift", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("ShiftId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<Guid?>("OwnerId");

                    b.HasKey("Id", "ShiftId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShiftId");

                    b.ToTable("EmployeeShift");
                });

            modelBuilder.Entity("HRM.Model.Entities.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Address");

                    b.Property<int>("BasicSalary")
                        .HasColumnName("BasicSalary");

                    b.Property<decimal>("Coefficient")
                        .HasColumnName("Coefficient");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnName("EmployeeName");

                    b.Property<int?>("Flags");

                    b.Property<DateTime>("HireDay")
                        .HasColumnName("HireDay");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("IsManager")
                        .HasColumnName("IsManager");

                    b.Property<DateTime?>("LastModified");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone");

                    b.Property<Guid>("PositionId")
                        .HasColumnName("PositionId");

                    b.Property<Guid>("UnitId")
                        .HasColumnName("UnitId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("UnitId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HRM.Model.Entities.Factory.Factory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<Guid?>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Factory");
                });

            modelBuilder.Entity("HRM.Model.Entities.Position.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PositionId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnName("Note");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnName("PositionName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.ApproveDayOff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApproverId");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<Guid?>("OwnerId");

                    b.Property<Guid>("RequestTypeId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<Guid>("TimeOffId");

                    b.HasKey("Id");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("TimeOffId")
                        .IsUnique();

                    b.ToTable("ApproveDayOff");
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.ChangeShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("FactoryName")
                        .IsRequired()
                        .HasColumnName("FactoryName");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("NewShift")
                        .IsRequired()
                        .HasColumnName("NewShift");

                    b.Property<string>("OldShift")
                        .IsRequired()
                        .HasColumnName("OldShift");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnName("Receiver");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnName("Sender");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnName("UnitName");

                    b.HasKey("Id");

                    b.ToTable("ChangeShift");
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.RequestType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("NameRequest");

                    b.Property<Guid?>("OwnerId");

                    b.Property<double>("Percent");

                    b.HasKey("Id");

                    b.ToTable("RequestType");
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.TimeOff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("Content");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime>("End")
                        .HasColumnName("End");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsAllDay")
                        .HasColumnName("IsAllDay");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<Guid?>("OwnerId");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnName("Receiver");

                    b.Property<Guid>("SenderId")
                        .HasColumnName("Sender");

                    b.Property<DateTime>("Start")
                        .HasColumnName("Start");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("TimeOff");
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.TransferWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnName("Reason");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnName("ReceiverId");

                    b.Property<Guid>("SendById")
                        .HasColumnName("SendById");

                    b.Property<Guid>("UnitFrom")
                        .HasColumnName("UnitFrom");

                    b.Property<Guid>("UnitTo")
                        .HasColumnName("UnitTo");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SendById");

                    b.HasIndex("UnitFrom");

                    b.HasIndex("UnitTo");

                    b.ToTable("TransferWork");
                });

            modelBuilder.Entity("HRM.Model.Entities.Shifts.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<float>("Marks")
                        .HasColumnName("Marks");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasColumnName("ShiftName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("HRM.Model.Entities.Unit.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CostAccountNumber")
                        .HasColumnName("CostAccountNumber");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<Guid>("FactoryId")
                        .HasColumnName("FactoryId");

                    b.Property<int?>("Flags");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<Guid?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("HRM.Model.Entities.EmployeeShift", b =>
                {
                    b.HasOne("HRM.Model.Entities.Employees.Employee", "Employees")
                        .WithMany("EmployeeShifts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRM.Model.Entities.Shifts.Shift", "Shifts")
                        .WithMany("EmployeeShifts")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRM.Model.Entities.Employees.Employee", b =>
                {
                    b.HasOne("HRM.Model.Entities.Position.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRM.Model.Entities.Unit.Unit", "Unit")
                        .WithMany("Employees")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.ApproveDayOff", b =>
                {
                    b.HasOne("HRM.Model.Entities.Request.RequestType", "RequestType")
                        .WithMany("ApproveDayOffs")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRM.Model.Entities.Request.TimeOff", "TimeOff")
                        .WithOne("ApproveDayOff")
                        .HasForeignKey("HRM.Model.Entities.Request.ApproveDayOff", "TimeOffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.TimeOff", b =>
                {
                    b.HasOne("HRM.Model.Entities.Employees.Employee", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRM.Model.Entities.Employees.Employee", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRM.Model.Entities.Request.TransferWork", b =>
                {
                    b.HasOne("HRM.Model.Entities.Employees.Employee", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRM.Model.Entities.Employees.Employee", "Sender")
                        .WithMany()
                        .HasForeignKey("SendById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRM.Model.Entities.Unit.Unit", "OldUnit")
                        .WithMany()
                        .HasForeignKey("UnitFrom")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRM.Model.Entities.Unit.Unit", "NewUnit")
                        .WithMany()
                        .HasForeignKey("UnitTo")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRM.Model.Entities.Unit.Unit", b =>
                {
                    b.HasOne("HRM.Model.Entities.Factory.Factory", "Factory")
                        .WithMany("Units")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
