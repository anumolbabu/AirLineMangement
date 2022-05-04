using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminService.Models
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

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET96;Database=AirLineDB;User ID=sa;Password=pass@word1;Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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
