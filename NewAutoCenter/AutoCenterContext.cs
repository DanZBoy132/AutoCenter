using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewAutoCenter;

namespace Auto_Center;

public partial class AutoCenterContext : DbContext
{
    public AutoCenterContext()
    {
    }

    public AutoCenterContext(DbContextOptions<AutoCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarInMagazine> CarInMagazines { get; set; }

    public virtual DbSet<CarInUsing> CarInUsings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Auto_Center;Username=postgres;Password=7520");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarInMagazine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Car_in_Magazine_pkey");

            entity.ToTable("Car_in_Magazine");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Mark).HasMaxLength(256);
            entity.Property(e => e.Model).HasMaxLength(256);
            entity.Property(e => e.YearsBorn).HasColumnName("years_born");
        });

        modelBuilder.Entity<CarInUsing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Car_in_Using_pkey");

            entity.ToTable("Car_in_Using");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Mark).HasMaxLength(256);
            entity.Property(e => e.Model).HasMaxLength(256);
            entity.Property(e => e.YearsUsing).HasColumnName("years_using");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(256)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(256);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Cash).HasColumnName("Cash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
