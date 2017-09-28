using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace NuDataDb.EFMigrationHistory
{
    public partial class MigrationHistoryContext : DbContext
    {
        public virtual DbSet<DatabaseHistory> DatabaseHistory { get; set; }
        public virtual DbSet<PatientHistory> PatientHistory { get; set; }
        public virtual DbSet<TableHistory> TableHistory { get; set; }
        public virtual DbSet<UserHistory> UserHistory { get; set; }

        public readonly string ConnectionStr = String.Empty;

        public MigrationHistoryContext(DbContextOptions<MigrationHistoryContext> options) : base(options)
        {
            if (options.FindExtension<SqlServerOptionsExtension>() != null)
            {
                ConnectionStr = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.Property(e => e.FbConnectionStringUsed)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.InstitutionName).HasMaxLength(150);

                entity.Property(e => e.LastMigrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SiteId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PatientHistory>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirebirdPatientId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.MigrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Migration)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.MigrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientHistory_DatabaseHistory");
            });

            modelBuilder.Entity<TableHistory>(entity =>
            {
                entity.HasKey(e => e.TableMigrationId);

                entity.Property(e => e.FirebirdRecordCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastMigrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedRecordCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Migration)
                    .WithMany(p => p.TableHistory)
                    .HasForeignKey(d => d.MigrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TableHistory_DatabaseHistory");
            });

            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.MigrationDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Migration)
                    .WithMany(p => p.UserHistory)
                    .HasForeignKey(d => d.MigrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserHistory_DatabaseHistory");
            });
        }
    }
}
