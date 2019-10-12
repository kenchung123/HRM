using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HRM.Model.Entities;
using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Factory;
using HRM.Model.Entities.Position;
using HRM.Model.Entities.Request;
using HRM.Model.Entities.Shifts;
using HRM.Model.Entities.Unit;

namespace HRM.Model
{
    public class HRMDBContext : DbContext
    {
        public HRMDBContext(DbContextOptions<HRMDBContext> options)
            : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<TimeOff> TimeOffs { get; set; }
        public DbSet<ChangeShift> ChangeShifts { get; set; }
        public DbSet<TransferWork> TransferWorks { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ApproveDayOff> ApproveDayOffs { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Position> Positions { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            base.OnModelCreating(modelBuilder);

            //primary key
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.EmployeeName).HasColumnName("EmployeeName");
                entity.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Phone).HasColumnName("Phone");
                entity.Property(e => e.HireDay).HasColumnName("HireDay");
                entity.Property(e => e.PositionId).HasColumnName("PositionId");
                entity.Property(e => e.BasicSalary).HasColumnName("BasicSalary");
                entity.Property(e => e.Coefficient).HasColumnName("Coefficient");
                entity.Property(e => e.UnitId).HasColumnName("UnitId");
                entity.Property(e => e.IsManager).HasColumnName("IsManager");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ShiftName).HasColumnName("ShiftName");
                entity.Property(e => e.Marks).HasColumnName("Marks");
            });

            modelBuilder.Entity<TimeOff>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.SenderId).HasColumnName("Sender");
                entity.Property(e => e.ReceiverId).HasColumnName("Receiver");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.IsAllDay).HasColumnName("IsAllDay");
                entity.Property(e => e.Start).HasColumnName("Start");
                entity.Property(e => e.End).HasColumnName("End");
                entity.Property(e => e.Content).HasColumnName("Content");
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<ChangeShift>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.SenderId).HasColumnName("Sender");
                entity.Property(e => e.ReceiverId).HasColumnName("Receiver");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.FactoryName).HasColumnName("FactoryName");
                entity.Property(e => e.UnitName).HasColumnName("UnitName");
                entity.Property(e => e.NewShift).HasColumnName("NewShift");
                entity.Property(e => e.OldShift).HasColumnName("OldShift");
                entity.Property(e => e.Content).HasColumnName("Content");
            });

            modelBuilder.Entity<TransferWork>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.SendById).HasColumnName("SendById");
                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverId");
                entity.Property(e => e.UnitFrom).HasColumnName("UnitFrom");
                entity.Property(e => e.UnitTo).HasColumnName("UnitTo");
                entity.Property(e => e.Reason).HasColumnName("Reason");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.CostAccountNumber).HasColumnName("CostAccountNumber");
                entity.Property(e => e.FactoryId).HasColumnName("FactoryId");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("PositionId");
                entity.Property(e => e.PositionName).HasColumnName("PositionName");
                entity.Property(e => e.Note).HasColumnName("Note");
            });

            modelBuilder.Entity<EmployeeShift>().HasOne(s => s.Shifts).WithMany(g => g.EmployeeShifts)
                .HasForeignKey(s => s.ShiftId);

            modelBuilder.Entity<EmployeeShift>().HasOne(s => s.Employees).WithMany(g => g.EmployeeShifts)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<TimeOff>()
                .HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(nameof(TimeOff.SenderId))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeOff>()
                .HasOne(e => e.Receiver)
                .WithMany()
                .HasForeignKey(nameof(TimeOff.ReceiverId))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferWork>()
                .HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(nameof(TransferWork.SendById))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferWork>()
                .HasOne(e => e.Receiver)
                .WithMany()
                .HasForeignKey(nameof(TransferWork.ReceiverId))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferWork>()
                .HasOne(e => e.OldUnit)
                .WithMany()
                .HasForeignKey(nameof(TransferWork.UnitFrom))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferWork>()
                .HasOne(e => e.NewUnit)
                .WithMany()
                .HasForeignKey(nameof(TransferWork.UnitTo))
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeShift>().HasKey(st => new {st.Id, st.ShiftId});
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}