﻿using System;
using System.Collections.Generic;
using API_desde_cero_JR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API_desde_cero_JR.Data;

public partial class BdsJrParaApiDesdeCeroContext86f84c455e114ccc855cB472bbb92788Context : DbContext
{
    public BdsJrParaApiDesdeCeroContext86f84c455e114ccc855cB472bbb92788Context()
    {
    }

    public BdsJrParaApiDesdeCeroContext86f84c455e114ccc855cB472bbb92788Context(DbContextOptions<BdsJrParaApiDesdeCeroContext86f84c455e114ccc855cB472bbb92788Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Burger> Burgers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BDs_JR_para_API_desde_ceroContext-86f84c45-5e11-4ccc-855c-b472bbb92788;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger>(entity =>
        {
            entity.ToTable("Burger");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurgerId, "IX_Promo_BurgerID");

            entity.Property(e => e.PromoId).HasColumnName("PromoID");
            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");

            entity.HasOne(d => d.Burger).WithMany(p => p.Promos).HasForeignKey(d => d.BurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
