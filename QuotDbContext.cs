using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapiqoute.Models;

public partial class QuotDbContext : DbContext
{
    public QuotDbContext()
    {
    }

    public QuotDbContext(DbContextOptions<QuotDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Quote> Quotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quote>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("quotes");

            entity.Property(e => e.Advice).IsUnicode(false);
            entity.Property(e => e.AdviceCatagory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Advice_Catagory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
