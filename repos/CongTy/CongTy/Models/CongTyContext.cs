using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CongTy.Models
{
    public partial class CongTyContext : DbContext
    {
        public CongTyContext()
        {
        }

        public CongTyContext(DbContextOptions<CongTyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<PhongBan> PhongBans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JOL4JRB;Database=CongTy;Integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaNV");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(30);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("FK_NhanVien_PhongBan");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPhong);

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenPhong).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
