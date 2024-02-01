using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using APIEntryDtls;

namespace APIEntryDtls.AppData;

public partial class DummyContext : DbContext
{
    public DummyContext()
    {
    }

    public DummyContext(DbContextOptions<DummyContext> options)
        : base(options)
    {
    }
    public virtual DbSet<EntryDetail> EntryDetails { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=SUDIPTA-DELL;initial catalog=Dummy;integrated security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntryDetail>(entity =>
        {
            entity.HasKey(e => e.EntrId);

            entity.HasIndex(e => e.Pid, "IX_EntryDetails").IsUnique();

            entity.Property(e => e.EntrId).HasColumnName("entrId");
            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LName");
            entity.Property(e => e.Pid).HasColumnName("PId");
            entity.Property(e => e.Pin)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

       // OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<APIEntryDtls.EntryDetailsClass>? EntryDetailsClass { get; set; }
}
