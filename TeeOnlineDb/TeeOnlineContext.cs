using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeeOnlineDb
{
    public partial class TeeOnlineContext : DbContext
    {
        public TeeOnlineContext()
        {
        }

        public TeeOnlineContext(DbContextOptions<TeeOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<GolfClub> GolfClubs { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("data source=C:\\OneDrive\\Schule\\5_Klasse\\POS_SYNCED\\createWebApiProjectnet6\\TeeOnline\\TeeOnlineDb\\.\\TeeOnline.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasIndex(e => e.GolfClubId, "IX_Bookings_GolfClubId");

                entity.HasOne(d => d.GolfClub)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GolfClubId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.HomeGolfClubGolfClubId, "IX_Players_HomeGolfClubGolfClubId");

                entity.Property(e => e.Email).HasColumnName("EMail");

                entity.HasOne(d => d.HomeGolfClubGolfClub)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.HomeGolfClubGolfClubId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.Bookings)
                    .WithMany(p => p.Players)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlayerBooking",
                        l => l.HasOne<Booking>().WithMany().HasForeignKey("BookingId"),
                        r => r.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                        j =>
                        {
                            j.HasKey("PlayerId", "BookingId");

                            j.ToTable("PlayerBookings");

                            j.HasIndex(new[] { "BookingId" }, "IX_PlayerBookings_BookingId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
