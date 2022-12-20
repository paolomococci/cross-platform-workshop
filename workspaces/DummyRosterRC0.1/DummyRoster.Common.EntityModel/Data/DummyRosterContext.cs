using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DummyRoster.Common.EntityModel.Models;

public partial class DummyRosterContext : DbContext
{
    public DummyRosterContext()
    {
    }

    public DummyRosterContext(DbContextOptions<DummyRosterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;

    public virtual DbSet<Carrier> Carriers { get; set; } = null!;

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<Credential> Credentials { get; set; } = null!;

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    public virtual DbSet<Employee> Employees { get; set; } = null!;

    public virtual DbSet<Form> Forms { get; set; } = null!;

    public virtual DbSet<Invoice> Invoices { get; set; } = null!;

    public virtual DbSet<Product> Products { get; set; } = null!;

    public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Filename=../DummyRoster.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Form>(entity =>
        {
            entity.Property(e => e.ShippingCost).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.PriceCut).HasDefaultValueSql("0");
            entity.Property(e => e.Quantity).HasDefaultValueSql("1");
            entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Discontinued).HasDefaultValueSql("0");
            entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");
            entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");
            entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
