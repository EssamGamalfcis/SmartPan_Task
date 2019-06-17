using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain
{
    public partial class SmartPan_TaskContext : DbContext
    {
        public SmartPan_TaskContext()
        {
        }

        public SmartPan_TaskContext(DbContextOptions<SmartPan_TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departements> Departements { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesTasks> EmployeesTasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-51CBLQL\\SQLEXPRESS;Initial Catalog=SmartPan_Task;Persist Security Info=True;User ID=sa1;pwd=essam2014;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Departements>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.Property(e => e.DepId).HasColumnName("Dep_Id");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnName("Dep_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.DeleteFlag).HasColumnName("Delete_Flag");

                entity.Property(e => e.DepId).HasColumnName("Dep_Id");

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasColumnName("Emp_FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpImage)
                    .IsRequired()
                    .HasColumnName("Emp_Image")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasColumnName("Emp_LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSalary).HasColumnName("Emp_Salary");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departements");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<EmployeesTasks>(entity =>
            {
                entity.ToTable("Employees_Tasks");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.TaskStatusId).HasColumnName("Task_Status_Id");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeesTasks)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Tasks_Employees");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.EmployeesTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Tasks_Tasks");

                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.EmployeesTasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Tasks_Task_Status");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("Task_Status");

                entity.Property(e => e.TaskStatusId).HasColumnName("Task_Status_Id");

                entity.Property(e => e.TaskStatus1)
                    .IsRequired()
                    .HasColumnName("Task_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("Task_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User_Role");

                entity.Property(e => e.UserRoleId).HasColumnName("User_Role_Id");

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasColumnName("User_Description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.UserLoginName)
                    .IsRequired()
                    .HasColumnName("User_Login_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("User_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("User_Role_Id");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Employees");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_User_Role");
            });
        }
    }
}
