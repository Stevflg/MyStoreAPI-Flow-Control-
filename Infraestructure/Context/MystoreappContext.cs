using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.context;

public partial class MyStoreAppContext : DbContext
{
    public MyStoreAppContext()
    {
    }

    public MyStoreAppContext(DbContextOptions<MyStoreAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Invoicedetail> Invoicedetails { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Producttype> Producttypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rolscreenui> Rolscreenuis { get; set; }

    public virtual DbSet<Screensui> Screensuis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrol> Userrols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
