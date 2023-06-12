using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VietNamTourism.Models
{
    public partial class vietnamContext : DbContext
    {
        public vietnamContext()
        {
        }

        public vietnamContext(DbContextOptions<vietnamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Phanhoi> Phanhois { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JOL4JRB;Database=vietnam;Integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phanhoi>(entity =>
            {
                entity.HasKey(e => e.Maphanhoi)
                    .HasName("PK__phanhoi__BB6B959947019746");

                entity.ToTable("phanhoi");

                entity.Property(e => e.Maphanhoi).HasColumnName("maphanhoi");

                entity.Property(e => e.Manguoidung)
                    .HasMaxLength(50)
                    .HasColumnName("manguoidung");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(50)
                    .HasColumnName("noidung");

                entity.Property(e => e.Trangthaiphanhoi)
                    .HasMaxLength(50)
                    .HasColumnName("trangthaiphanhoi");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap);

                entity.ToTable("taikhoan");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(50)
                    .HasColumnName("tendangnhap");

                entity.Property(e => e.Manguoidung)
                    .HasMaxLength(50)
                    .HasColumnName("manguoidung");

                entity.Property(e => e.Maquyen)
                    .HasMaxLength(50)
                    .HasColumnName("maquyen");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .HasColumnName("matkhau");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
