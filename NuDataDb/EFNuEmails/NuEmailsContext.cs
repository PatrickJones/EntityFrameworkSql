using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace NuDataDb.EFNuEmails
{
    public partial class NuEmailsContext : DbContext
    {
        public virtual DbSet<DomainTypes> DomainTypes { get; set; }
        public virtual DbSet<EmailAddresses> EmailAddresses { get; set; }
        public virtual DbSet<EmailCategories> EmailCategories { get; set; }
        public virtual DbSet<EmailDocuments> EmailDocuments { get; set; }
        public virtual DbSet<ServerLocationTypes> ServerLocationTypes { get; set; }

        public readonly string ConnectionStr = String.Empty;

        public NuEmailsContext(DbContextOptions<NuEmailsContext> options) : base(options)
        {
            if (options.FindExtension<SqlServerOptionsExtension>() != null)
            {
                ConnectionStr = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainTypes>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<EmailAddresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<EmailCategories>(entity =>
            {
                entity.HasKey(e => e.EmailTypeId);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<EmailDocuments>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ServerLocationTypes>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.Server)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
