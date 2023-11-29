using System;
using System.Collections.Generic;
using Cars.CarsDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.CarsDb.Context;

public partial class CarsDbContext : DbContext
{
    public CarsDbContext()
    {
    }

    public CarsDbContext(DbContextOptions<CarsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarEngine> CarEngines { get; set; }

    public virtual DbSet<CarStrongPoint> CarStrongPoints { get; set; }

    public virtual DbSet<CarWeakPoint> CarWeakPoints { get; set; }

    public virtual DbSet<CategoryCar> CategoryCars { get; set; }

    public virtual DbSet<CategoryEngine> CategoryEngines { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<MatchupCar> MatchupCars { get; set; }

    public virtual DbSet<StrongPoint> StrongPoints { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<VolumeEngine> VolumeEngines { get; set; }

    public virtual DbSet<WeakPoint> WeakPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC072E553CD7");

            entity.ToTable("Car");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.CategoryCar).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CategoryCarId)
                .HasConstraintName("FK__Car__CategoryCar__33D4B598");
        });

        modelBuilder.Entity<CarEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarEngin__3214EC07ED7F2A9C");

            entity.ToTable("CarEngine");

            entity.HasOne(d => d.Car).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarEngine__CarId__36B12243");

            entity.HasOne(d => d.Engine).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.EngineId)
                .HasConstraintName("FK__CarEngine__Engin__37A5467C");
        });

        modelBuilder.Entity<CarStrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarStron__3214EC070712A823");

            entity.ToTable("CarStrongPoint");

            entity.HasOne(d => d.Car).WithMany(p => p.CarStrongPoints)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarStrong__CarId__3A81B327");

            entity.HasOne(d => d.StrongPoint).WithMany(p => p.CarStrongPoints)
                .HasForeignKey(d => d.StrongPointId)
                .HasConstraintName("FK__CarStrong__Stron__3B75D760");
        });

        modelBuilder.Entity<CarWeakPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarWeakP__3214EC075639F99C");

            entity.ToTable("CarWeakPoint");

            entity.HasOne(d => d.Car).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarWeakPo__CarId__3E52440B");

            entity.HasOne(d => d.WeakPoint).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.WeakPointId)
                .HasConstraintName("FK__CarWeakPo__WeakP__3F466844");
        });

        modelBuilder.Entity<CategoryCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC071F7B1B4C");

            entity.ToTable("CategoryCar");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoryEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0726AFD90E");

            entity.ToTable("CategoryEngine");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Engine__3214EC0794B3D536");

            entity.ToTable("Engine");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CategoryEngine).WithMany(p => p.Engines)
                .HasForeignKey(d => d.CategoryEngineId)
                .HasConstraintName("FK__Engine__Category__29572725");

            entity.HasOne(d => d.VolumeEngine).WithMany(p => p.Engines)
                .HasForeignKey(d => d.VolumeEngineId)
                .HasConstraintName("FK__Engine__VolumeEn__2A4B4B5E");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guide__3214EC076F1976B9");

            entity.ToTable("Guide");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<MatchupCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MatchupC__3214EC07C598B268");

            entity.ToTable("MatchupCar");

            entity.HasOne(d => d.Bad).WithMany(p => p.MatchupCarBads)
                .HasForeignKey(d => d.BadId)
                .HasConstraintName("FK__MatchupCa__BadId__4316F928");

            entity.HasOne(d => d.Good).WithMany(p => p.MatchupCarGoods)
                .HasForeignKey(d => d.GoodId)
                .HasConstraintName("FK__MatchupCa__GoodI__4222D4EF");
        });

        modelBuilder.Entity<StrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StrongPo__3214EC07CA6A606E");

            entity.ToTable("StrongPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tutorial__3214EC07D96229EE");

            entity.ToTable("Tutorial");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<VolumeEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VolumeEn__3214EC07CC8DC544");

            entity.ToTable("VolumeEngine");

            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<WeakPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeakPoin__3214EC07F404CBEB");

            entity.ToTable("WeakPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
