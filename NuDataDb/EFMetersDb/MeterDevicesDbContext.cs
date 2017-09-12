using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NuDataDb.EFMetersDb
{
    public partial class MeterDevicesDbContext : DbContext
    {
        public virtual DbSet<DeviceHost> DeviceHost { get; set; }
        public virtual DbSet<DeviceHostLog> DeviceHostLog { get; set; }
        public virtual DbSet<DeviceHostMessages> DeviceHostMessages { get; set; }
        public virtual DbSet<DeviceHostStatusTypes> DeviceHostStatusTypes { get; set; }
        public virtual DbSet<InstructionItems> InstructionItems { get; set; }
        public virtual DbSet<LogMessageTypes> LogMessageTypes { get; set; }
        public virtual DbSet<Meters> Meters { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }

        // can only have a single option per instance.
        private bool UseDefaultBuilder { get; set; } = true;

        public MeterDevicesDbContext(DbContextOptions<MeterDevicesDbContext> options) : base(options) { UseDefaultBuilder = false; }
        public MeterDevicesDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (UseDefaultBuilder)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=STAGESERVER\SQLDEV2014;Database=MeterDevicesDb;User=nuweb;Password=P@ssw0rd;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceHost>(entity =>
            {
                entity.Property(e => e.DeviceHostId).ValueGeneratedNever();

                entity.Property(e => e.ComputerName).HasMaxLength(250);

                entity.Property(e => e.InstallDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.IsInstitution).HasDefaultValueSql("((0))");

                entity.Property(e => e.Macaddress)
                    .HasColumnName("MACAddress")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceHostLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogMessageCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.LogMessageType).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.DeviceHost)
                    .WithMany(p => p.DeviceHostLog)
                    .HasForeignKey(d => d.DeviceHostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceHostLog_DeviceHost");
            });

            modelBuilder.Entity<DeviceHostMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message).IsRequired();
            });

            modelBuilder.Entity<DeviceHostStatusTypes>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InstructionItems>(entity =>
            {
                entity.HasIndex(e => e.MeterId)
                    .HasName("IX_Meter_Id");

                entity.Property(e => e.Instruction).HasColumnType("nvarchar");

                entity.Property(e => e.MeterId).HasColumnName("Meter_Id");

                entity.HasOne(d => d.Meter)
                    .WithMany(p => p.InstructionItems)
                    .HasForeignKey(d => d.MeterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.InstructionItems_dbo.Meters_Meter_Id");
            });

            modelBuilder.Entity<LogMessageTypes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Meters>(entity =>
            {
                entity.Property(e => e.CurrentlyActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsuletMarket).HasDefaultValueSql("((0))");

                entity.Property(e => e.MeterPid).HasColumnName("MeterPID");

                entity.Property(e => e.MeterVid).HasColumnName("MeterVID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}
