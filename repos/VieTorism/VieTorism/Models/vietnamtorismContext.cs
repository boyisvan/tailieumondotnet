using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VieTorism.Models
{
    public partial class vietnamtorismContext : DbContext
    {
        public vietnamtorismContext()
        {
        }

        public vietnamtorismContext(DbContextOptions<vietnamtorismContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Danhmuc> Danhmucs { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Phanhoi> Phanhois { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JOL4JRB;Database=vietnamtorism;Integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.Madanhmuc);

                entity.ToTable("danhmuc");

                entity.Property(e => e.Madanhmuc)
                    .HasMaxLength(30)
                    .HasColumnName("madanhmuc");

                entity.Property(e => e.Tendanhmuc)
                    .HasMaxLength(30)
                    .HasColumnName("tendanhmuc");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(30)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap);

                entity.ToTable("nguoidung");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(30)
                    .HasColumnName("tendangnhap");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(30)
                    .HasColumnName("diachi");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(30)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Hovaten)
                    .HasMaxLength(30)
                    .HasColumnName("hovaten");

                entity.Property(e => e.Tuoi)
                    .HasMaxLength(30)
                    .HasColumnName("tuoi");

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithOne(p => p.Nguoidung)
                    .HasForeignKey<Nguoidung>(d => d.Tendangnhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nguoidung_TaiKhoan1");
            });

            modelBuilder.Entity<Phanhoi>(entity =>
            {
                entity.ToTable("phanhoi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(50)
                    .HasColumnName("noidung");

                entity.Property(e => e.Tennguoiphanhoi)
                    .HasMaxLength(50)
                    .HasColumnName("tennguoiphanhoi");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Role1)
                    .HasName("PK_Role");

                entity.ToTable("role");

                entity.Property(e => e.Role1)
                    .HasMaxLength(30)
                    .HasColumnName("role");

                entity.Property(e => e.Tenrole)
                    .HasMaxLength(30)
                    .HasColumnName("tenrole");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("sanpham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anh)
                    .HasMaxLength(150)
                    .HasColumnName("anh");

                entity.Property(e => e.Danhgia)
                    .HasMaxLength(30)
                    .HasColumnName("danhgia");

                entity.Property(e => e.Madanhmuc)
                    .HasMaxLength(30)
                    .HasColumnName("madanhmuc");

                entity.Property(e => e.Mota)
                    .HasMaxLength(30)
                    .HasColumnName("mota");

                entity.Property(e => e.Tensanpham)
                    .HasMaxLength(30)
                    .HasColumnName("tensanpham");

                entity.HasOne(d => d.MadanhmucNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Madanhmuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sanpham_danhmuc");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap)
                    .HasName("PK_TaiKhoan");

                entity.ToTable("taikhoan");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(30)
                    .HasColumnName("tendangnhap");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(30)
                    .HasColumnName("matkhau");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .HasColumnName("role");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(30)
                    .HasColumnName("trangthai");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Taikhoans)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_TaiKhoan_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
