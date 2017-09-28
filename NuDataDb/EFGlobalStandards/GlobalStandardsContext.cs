using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace NuDataDb.EFGlobalStandards
{
    public partial class GlobalStandardsContext : DbContext
    {
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Continents> Continents { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<DiabetesQuestions> DiabetesQuestions { get; set; }
        public virtual DbSet<ExerciseFrequency> ExerciseFrequency { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<ExertionLevels> ExertionLevels { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public virtual DbSet<States> States { get; set; }

        public readonly string ConnectionStr = String.Empty;

        public GlobalStandardsContext(DbContextOptions<GlobalStandardsContext> options) : base(options)
        {
            if (options.FindExtension<SqlServerOptionsExtension>() != null)
            {
                ConnectionStr = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.AccentName).HasMaxLength(150);

                entity.Property(e => e.Latitude).HasMaxLength(150);

                entity.Property(e => e.Longitude).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.TimeZone).HasMaxLength(80);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<Continents>(entity =>
            {
                entity.HasKey(e => e.ContinentId);

                entity.Property(e => e.ContinentCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Countries_Continents");
            });

            modelBuilder.Entity<DiabetesQuestions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<ExerciseFrequency>(entity =>
            {
                entity.HasKey(e => e.FrequencyId);

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasKey(e => e.ExerciseId);

                entity.Property(e => e.ExerciseType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExertionLevels>(entity =>
            {
                entity.HasKey(e => e.ExertionId);

                entity.Property(e => e.ExertionLevel)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnName("Gender")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ThreeLetter)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.TwoLetter).HasMaxLength(2);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PhoneTypes>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SecurityQuestions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StateCode).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });
        }
    }
}
