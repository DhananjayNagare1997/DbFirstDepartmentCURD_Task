using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DepartmentCURD_DBFirst.Models;

public partial class TestDepartmentContext : DbContext
{
    /*public TestDepartmentContext()
    {
    }*/

    public TestDepartmentContext(DbContextOptions<TestDepartmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WJLP-1424;Database=TestDepartment;User=DJ;Password=Password@1997;TrustServerCertificate=true;Trusted_Connection=True;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDE004BD1D");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepartmentHead).HasMaxLength(255);
            entity.Property(e => e.DepartmentName).HasMaxLength(255);
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
