﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using qltv.Models;

namespace qltv.data
{
    public partial class Vido_QltvContext : DbContext
    {
        public Vido_QltvContext()
        {
        }

        public Vido_QltvContext(DbContextOptions<Vido_QltvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booklist> Booklists { get; set; }
        public virtual DbSet<Muon> Muons { get; set; }
        public virtual DbSet<NhaXb> NhaXbs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Sinhvien> Sinhviens { get; set; }
        public virtual DbSet<Tacgia> Tacgia { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Thuthu> Thuthus { get; set; }
        public virtual DbSet<Tra> Tras { get; set; }
        public virtual DbSet<Vitri> Vitris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Booklist");

                entity.Property(e => e.NamXb).HasColumnName("NamXB");

                entity.Property(e => e.Tacgia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenNxb)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenNXB");

                entity.Property(e => e.Tensach)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Theloai).HasMaxLength(100);

                entity.Property(e => e.VitriHang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VitriKe)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Muon>(entity =>
            {
                entity.ToTable("Muon");

                entity.HasIndex(e => e.SinhvienId, "IFK_MuonSinhvienId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.ThuthuId, "IFK_MuonThuthuId")
                    .HasFillFactor(80);

                entity.Property(e => e.MuonId).ValueGeneratedNever();

                entity.Property(e => e.Ngaymuon).HasColumnType("date");

                entity.HasOne(d => d.Sach)
                    .WithMany(p => p.Muons)
                    .HasForeignKey(d => d.SachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonSachId");

                entity.HasOne(d => d.Sinhvien)
                    .WithMany(p => p.Muons)
                    .HasForeignKey(d => d.SinhvienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonSinhvienId");

                entity.HasOne(d => d.Thuthu)
                    .WithMany(p => p.Muons)
                    .HasForeignKey(d => d.ThuthuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonThuthuId");
            });

            modelBuilder.Entity<NhaXb>(entity =>
            {
                entity.ToTable("NhaXB");

                entity.HasIndex(e => e.Email, "UQ__NhaXB__A9D10534F265F4C5")
                    .IsUnique();

                entity.Property(e => e.NhaXbid)
                    .ValueGeneratedNever()
                    .HasColumnName("NhaXBId");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Tenxuatban)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThongtinNguoiDaiDien).HasMaxLength(100);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.ToTable("Sach");

                entity.HasIndex(e => e.NhaXbid, "IFK_SachNhaXBId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.TacgiaId, "IFK_SachTacgiaId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.TheloaiId, "IFK_SachTheloaiId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.VitriId, "IFK_SachVitriId")
                    .HasFillFactor(80);

                entity.Property(e => e.SachId).ValueGeneratedNever();

                entity.Property(e => e.Masach).HasMaxLength(30);

                entity.Property(e => e.NamXb).HasColumnName("NamXB");

                entity.Property(e => e.NhaXbid).HasColumnName("NhaXBId");

                entity.Property(e => e.Tensach)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.NhaXb)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.NhaXbid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SachNhaXBId");

                entity.HasOne(d => d.Tacgia)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.TacgiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SachTacgiaId");

                entity.HasOne(d => d.Theloai)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.TheloaiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SachTheloaiId");

                entity.HasOne(d => d.Vitri)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.VitriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SachVitriId");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.ToTable("Sinhvien");

                entity.HasIndex(e => e.SinhvienId, "UQ__Sinhvien__159718919C34B278")
                    .IsUnique();

                entity.Property(e => e.SinhvienId).ValueGeneratedNever();

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Khoa).HasMaxLength(60);

                entity.Property(e => e.Lop)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Masosinhvien)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.SoCmnd)
                    .HasMaxLength(30)
                    .HasColumnName("SoCMND");

                entity.Property(e => e.Tensinhvien)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.TacgiaId);

                entity.Property(e => e.TacgiaId).ValueGeneratedNever();

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Tentacgia)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.ToTable("TheLoai");

                entity.HasIndex(e => e.TheloaiId, "UQ__TheLoai__F373B1D0E682CFF8")
                    .IsUnique();

                entity.Property(e => e.TheloaiId).ValueGeneratedNever();

                entity.Property(e => e.Tentheloai).HasMaxLength(100);
            });

            modelBuilder.Entity<Thuthu>(entity =>
            {
                entity.ToTable("Thuthu");

                entity.HasIndex(e => e.Username, "UQ__Thuthu__536C85E474970BE4")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Thuthu__A9D1053419BD7F3F")
                    .IsUnique();

                entity.Property(e => e.ThuthuId).ValueGeneratedNever();

                entity.Property(e => e.Diachi).HasMaxLength(70);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Hoten).HasMaxLength(40);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Ngaysinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(24)
                    .HasColumnName("SDT");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tra>(entity =>
            {
                entity.ToTable("Tra");

                entity.HasIndex(e => e.MuonId, "IFK_TraMuonId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.ThuthuId, "IFK_TraThuthuId")
                    .HasFillFactor(80);

                entity.Property(e => e.TraId).ValueGeneratedNever();

                entity.Property(e => e.Ngaytra).HasColumnType("date");

                entity.HasOne(d => d.Muon)
                    .WithMany(p => p.Tras)
                    .HasForeignKey(d => d.MuonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraMuonId");

                entity.HasOne(d => d.Thuthu)
                    .WithMany(p => p.Tras)
                    .HasForeignKey(d => d.ThuthuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraThuthuId");
            });

            modelBuilder.Entity<Vitri>(entity =>
            {
                entity.ToTable("Vitri");

                entity.Property(e => e.VitriId).ValueGeneratedNever();

                entity.Property(e => e.Soke)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Tenhang)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}