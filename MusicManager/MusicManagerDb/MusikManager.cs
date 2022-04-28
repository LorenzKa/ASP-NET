using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicManagerDb
{
    public partial class MusikManager : DbContext
    {
        public MusikManager()
        {
        }

        public MusikManager(DbContextOptions<MusikManager> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<RecordType> RecordTypes { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\mssqllocaldb; attachdbfilename=C:\\Users\\loren\\source\\repos\\LorenzKa\\ASP.NET\\CSharp\\MusicManager\\MusicManager\\Musik.mdf;integrated security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.RecordTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Records_Artist");

                entity.HasOne(d => d.RecordType)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.RecordTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Records_RecordType");
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_RecordType");

                entity.Property(e => e.Descr)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Records");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
