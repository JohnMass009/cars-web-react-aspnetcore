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

    public virtual DbSet<CarBadMatchup> CarBadMatchups { get; set; }

    public virtual DbSet<CarCategory> CarCategories { get; set; }

    public virtual DbSet<CarEngine> CarEngines { get; set; }

    public virtual DbSet<CarGoodMatchup> CarGoodMatchups { get; set; }

    public virtual DbSet<CarStrongPoint> CarStrongPoints { get; set; }

    public virtual DbSet<CarWeakPoint> CarWeakPoints { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<EngineCategory> EngineCategories { get; set; }

    public virtual DbSet<EngineVolume> EngineVolumes { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<StrongPoint> StrongPoints { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<WeakPoint> WeakPoints { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC07D10C8922");

            entity.ToTable("Car");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.CarCategory).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarCategoryId)
                .HasConstraintName("FK__Car__CarCategory__33D4B598");
        });

        modelBuilder.Entity<CarBadMatchup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarBadMa__3214EC0717867365");

            entity.ToTable("CarBadMatchup");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Bad).WithMany(p => p.CarBadMatchupBads)
                .HasForeignKey(d => d.BadId)
                .HasConstraintName("FK__CarBadMat__BadId__4CA06362");

            entity.HasOne(d => d.Car).WithMany(p => p.CarBadMatchupCars)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarBadMat__CarId__4BAC3F29");
        });

        modelBuilder.Entity<CarCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarCateg__3214EC076E5583D3");

            entity.ToTable("CarCategory");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CarEngine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarEngin__3214EC0795EF6D53");

            entity.ToTable("CarEngine");

            entity.HasOne(d => d.Car).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarEngine__CarId__36B12243");

            entity.HasOne(d => d.Engine).WithMany(p => p.CarEngines)
                .HasForeignKey(d => d.EngineId)
                .HasConstraintName("FK__CarEngine__Engin__37A5467C");
        });

        modelBuilder.Entity<CarGoodMatchup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarGoodM__3214EC07BC2F86B1");

            entity.ToTable("CarGoodMatchup");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Car).WithMany(p => p.CarGoodMatchupCars)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarGoodMa__CarId__46E78A0C");

            entity.HasOne(d => d.Good).WithMany(p => p.CarGoodMatchupGoods)
                .HasForeignKey(d => d.GoodId)
                .HasConstraintName("FK__CarGoodMa__GoodI__47DBAE45");
        });

        modelBuilder.Entity<CarStrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarStron__3214EC07F37E9464");

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
            entity.HasKey(e => e.Id).HasName("PK__CarWeakP__3214EC0720FB2822");

            entity.ToTable("CarWeakPoint");

            entity.HasOne(d => d.Car).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarWeakPo__CarId__3E52440B");

            entity.HasOne(d => d.WeakPoint).WithMany(p => p.CarWeakPoints)
                .HasForeignKey(d => d.WeakPointId)
                .HasConstraintName("FK__CarWeakPo__WeakP__3F466844");
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Engine__3214EC076F2C8702");

            entity.ToTable("Engine");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.EngineCategory).WithMany(p => p.Engines)
                .HasForeignKey(d => d.EngineCategoryId)
                .HasConstraintName("FK__Engine__EngineCa__29572725");

            entity.HasOne(d => d.EngineVolume).WithMany(p => p.Engines)
                .HasForeignKey(d => d.EngineVolumeId)
                .HasConstraintName("FK__Engine__EngineVo__2A4B4B5E");
        });

        modelBuilder.Entity<EngineCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EngineCa__3214EC07C71151BE");

            entity.ToTable("EngineCategory");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<EngineVolume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EngineVo__3214EC07F84049FE");

            entity.ToTable("EngineVolume");

            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guide__3214EC073B821026");

            entity.ToTable("Guide");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<StrongPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StrongPo__3214EC07BBBBFCBD");

            entity.ToTable("StrongPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tutorial__3214EC07597BEEAA");

            entity.ToTable("Tutorial");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<WeakPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeakPoin__3214EC07C0CAC2DF");

            entity.ToTable("WeakPoint");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
