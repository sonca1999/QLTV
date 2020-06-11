using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLTV.Models
{
    public partial class QLTVContext : DbContext
    {
        public QLTVContext()
        {
        }

        public QLTVContext(DbContextOptions<QLTVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctmuontra> Ctmuontra { get; set; }
        public virtual DbSet<Docgia> Docgia { get; set; }
        public virtual DbSet<Muontra> Muontra { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }
        public virtual DbSet<Theloai> Theloai { get; set; }
        public virtual DbSet<Thethuvien> Thethuvien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SONCA;Initial Catalog=QLTV;Persist Security Info=True;User ID=sa;Password=P@ssw0rd;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ctmuontra>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CTMUONTRA");

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaMt)
                    .IsRequired()
                    .HasColumnName("MaMT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ngaytra).HasColumnType("date");

                entity.HasOne(d => d.MaMtNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaMt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTMUONTRA__MaMT__1B0907CE");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTMUONTRA__MaSac__1BFD2C07");
            });

            modelBuilder.Entity<Docgia>(entity =>
            {
                entity.HasKey(e => e.MaDg)
                    .HasName("PK__DOCGIA__272586603BDA839D");

                entity.ToTable("DOCGIA");

                entity.Property(e => e.MaDg)
                    .HasColumnName("MaDG")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaThe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenDg)
                    .IsRequired()
                    .HasColumnName("TenDG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaTheNavigation)
                    .WithMany(p => p.Docgia)
                    .HasForeignKey(d => d.MaThe)
                    .HasConstraintName("FK__DOCGIA__MaThe__1CF15040");
            });

            modelBuilder.Entity<Muontra>(entity =>
            {
                entity.HasKey(e => e.MaMt)
                    .HasName("PK__MUONTRA__2725DFD58D672B96");

                entity.ToTable("MUONTRA");

                entity.Property(e => e.MaMt)
                    .HasColumnName("MaMT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaThe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ngaymuon).HasColumnType("date");

                entity.HasOne(d => d.MaTheNavigation)
                    .WithMany(p => p.Muontra)
                    .HasForeignKey(d => d.MaThe)
                    .HasConstraintName("FK__MUONTRA__MaThe__1DE57479");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__SACH__B235742DB933166B");

                entity.ToTable("SACH");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaTg)
                    .HasColumnName("MaTG")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaTl)
                    .HasColumnName("MaTL")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamSx)
                    .HasColumnName("NamSX")
                    .HasColumnType("date");

                entity.Property(e => e.TenSach).HasMaxLength(50);

                entity.HasOne(d => d.MaTgNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTg)
                    .HasConstraintName("FK__SACH__MaTG__1ED998B2");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTl)
                    .HasConstraintName("FK__SACH__MaTL__1FCDBCEB");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.MaTg)
                    .HasName("PK__TACGIA__27250074A1BAAC0E");

                entity.ToTable("TACGIA");

                entity.Property(e => e.MaTg)
                    .HasColumnName("MaTG")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.TenTg)
                    .HasColumnName("TenTG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK__THELOAI__27250071AC2C902F");

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTl)
                    .HasColumnName("MaTL")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenTl)
                    .HasColumnName("TenTL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thethuvien>(entity =>
            {
                entity.HasKey(e => e.MaThe)
                    .HasName("PK__THETHUVI__314EEAAF971B4A1E");

                entity.ToTable("THETHUVIEN");

                entity.Property(e => e.MaThe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgayBd)
                    .HasColumnName("NgayBD")
                    .HasColumnType("date");

                entity.Property(e => e.NgayHh)
                    .HasColumnName("NgayHH")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
