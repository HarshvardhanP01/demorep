using System;
using System.Collections.Generic;
using DBFirstNeat.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirstNeat.Data;

public partial class PayRollDbContext : DbContext
{
    public PayRollDbContext()
    {
    }

    public PayRollDbContext(DbContextOptions<PayRollDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MsSqlLocalDB;Database=PayRollDB;Trusted_Connection=True;MultipleActiveResultSets=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.DeptNo);

            entity.ToTable("Depts", "PayRollSystem");

            entity.Property(e => e.Dname)
                .HasMaxLength(50)
                .HasColumnName("DName");
            entity.Property(e => e.Loc).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
