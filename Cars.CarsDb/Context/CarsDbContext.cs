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
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC07BDAEA102");

            entity.ToTable("Car");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.CategoryCar).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CategoryCarId)
                .HasConstraintName("FK__Car__CategoryCar__46E78A0C");
        });

        modelBuilder.Entity<CarEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarEngin__3214EC07AE4D90D2");

            entity.ToTable("CarEngine");

            entity.HasOne(d => d.Car).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarEngine__CarId__49C3F6B7");

            entity.HasOne(d => d.Engine).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.EngineId)
                .HasConstraintName("FK__CarEngine__Engin__4AB81AF0");
        });

        modelBuilder.Entity<CarStrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarStron__3214EC0788F20E63");

            entity.ToTable("CarStrongPoint");

            entity.HasOne(d => d.Car).WithMany(p => p.CarStrongPoints)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarStrong__CarId__4D94879B");

            entity.HasOne(d => d.StrongPoint).WithMany(p => p.CarStrongPoints)
                .HasForeignKey(d => d.StrongPointId)
                .HasConstraintName("FK__CarStrong__Stron__4E88ABD4");
        });

        modelBuilder.Entity<CarWeakPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarWeakP__3214EC07006A99D1");

            entity.ToTable("CarWeakPoint");

            entity.HasOne(d => d.Car).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarWeakPo__CarId__5165187F");

            entity.HasOne(d => d.WeakPoint).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.WeakPointId)
                .HasConstraintName("FK__CarWeakPo__WeakP__52593CB8");
        });

        modelBuilder.Entity<CategoryCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0748DB1F41");

            entity.ToTable("CategoryCar");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoryEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07A434EB00");

            entity.ToTable("CategoryEngine");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Engine__3214EC0746DF93EB");

            entity.ToTable("Engine");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CategoryEngine).WithMany(p => p.Engines)
                .HasForeignKey(d => d.CategoryEngineId)
                .HasConstraintName("FK__Engine__Category__3C69FB99");

            entity.HasOne(d => d.VolumeEngine).WithMany(p => p.Engines)
                .HasForeignKey(d => d.VolumeEngineId)
                .HasConstraintName("FK__Engine__VolumeEn__3D5E1FD2");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guide__3214EC0716D629AE");

            entity.ToTable("Guide");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<MatchupCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MatchupC__3214EC072D4C9E0E");

            entity.ToTable("MatchupCar");

            entity.HasOne(d => d.Bad).WithMany(p => p.MatchupCarBads)
                .HasForeignKey(d => d.BadId)
                .HasConstraintName("FK__MatchupCa__BadId__5629CD9C");

            entity.HasOne(d => d.Good).WithMany(p => p.MatchupCarGoods)
                .HasForeignKey(d => d.GoodId)
                .HasConstraintName("FK__MatchupCa__GoodI__5535A963");
        });

        modelBuilder.Entity<StrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StrongPo__3214EC07DD76948D");

            entity.ToTable("StrongPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tutorial__3214EC07744DFA9D");

            entity.ToTable("Tutorial");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<VolumeEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VolumeEn__3214EC07346F7595");

            entity.ToTable("VolumeEngine");

            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<WeakPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeakPoin__3214EC0754FA2B1E");

            entity.ToTable("WeakPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
