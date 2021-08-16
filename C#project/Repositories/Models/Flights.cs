using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories.Models
{
    public partial class Flights : DbContext
    {
        public Flights()
        {
        }

        public Flights(DbContextOptions<Flights> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\USERS\\USER\\DOCUMENTS\\C#PROJECT\\DB\\DB\\FLIGHTS.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Landing).HasColumnType("datetime");

                entity.Property(e => e.Takeoff).HasColumnType("datetime");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flight__Company__3B75D760");

                entity.HasOne(d => d.FromNavigation)
                    .WithMany(p => p.FlightFromNavigation)
                    .HasForeignKey(d => d.From)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flight__From__3E52440B");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany(p => p.FlightToNavigation)
                    .HasForeignKey(d => d.To)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flight__To__3F466844");
            });
        }
    }
}
