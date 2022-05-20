using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace CoreModels.Models
{
    public partial class AirLineDBContext : DbContext
    {
        public AirLineDBContext()
        {
        }

        public AirLineDBContext(DbContextOptions<AirLineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<MealInfo> MealInfos { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.PnrNumber);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Createddate).HasColumnType("datetime");

                entity.Property(e => e.InstrumentUsed)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpadatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MealInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MealInfo");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.MealName)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.MealType)
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passenger");

                entity.Property(e => e.PassengerId).HasColumnName("PassengerID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MealId)
                    .HasMaxLength(10)
                    .HasColumnName("MealID")
                    .IsFixedLength(true);

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.FromPlace)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.ToPlace)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
