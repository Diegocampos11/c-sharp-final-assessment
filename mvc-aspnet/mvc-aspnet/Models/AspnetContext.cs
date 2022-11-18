using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mvc_aspnet.Models;

public partial class AspnetContext : DbContext
{
    public AspnetContext()
    {
    }

    public AspnetContext(DbContextOptions<AspnetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S67PI3S;Database=aspnet;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__claims__3213E83F69A4AEA8");

            entity.ToTable("claims");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Claims)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__claims__vehicle___29572725");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__owners__3213E83F05FBF841");

            entity.ToTable("owners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DriverLicense)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("driver_license");
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vehicles__3213E83FA0180676");

            entity.ToTable("vehicles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Vin)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("vin");
            entity.Property(e => e.Year)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("year");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__vehicles__owner___267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
