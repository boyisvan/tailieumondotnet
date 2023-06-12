using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vũ_Trụ_Điện_Thoại.Models
{
    public partial class vutrudienthoaiContext : DbContext
    {
        public vutrudienthoaiContext()
        {
        }

        public vutrudienthoaiContext(DbContextOptions<vutrudienthoaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JOL4JRB;Database=vutrudienthoai;Integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaChucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenChucVu)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc);

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDanhMuc)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenDanhMuc)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Ngay).HasColumnType("date");

                entity.Property(e => e.TongTienThanhToan)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_HoaDon_NhanVien");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_HoaDon_SanPham");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaNguoiDung)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenKhachHang)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Tuoi)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_KhachHang_TaiKhoan");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.HoTen)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaChucVu)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MaNguoiDung)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.MaChucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaChucVu)
                    .HasConstraintName("FK_NhanVien_ChucVu");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_NhanVien_TaiKhoan");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Gia)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.MaDanhMuc)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MoTa)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SoLuong)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenSanPham)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("FK_SanPham_DanhMuc");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaNguoiDung)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.LoaiTaiKhoan)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
