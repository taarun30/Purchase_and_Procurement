using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RetailStore.Models
{
    public class RetailStoreContext:DbContext
    {
        public RetailStoreContext():base("name=RetailStores")
        { }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrdersMaster> OrdersMasters { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderMaster> PurchaseOrderMasters { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
    

protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
        modelBuilder.Entity<Admin>()
            .Property(e => e.Username)
            .IsUnicode(false);

        modelBuilder.Entity<Admin>()
            .Property(e => e.Password)
            .IsUnicode(false);

        modelBuilder.Entity<Feedback>()
            .Property(e => e.FeedbackScore)
            .IsUnicode(false);

        modelBuilder.Entity<Inventory>()
            .Property(e => e.Productname)
            .IsUnicode(false);

        modelBuilder.Entity<Inventory>()
            .Property(e => e.ProductDescription)
            .IsUnicode(false);

        modelBuilder.Entity<Invoice>()
            .Property(e => e.InvoiceStatus)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.CompanyName)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Firstname)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Lastname)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Address)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.City)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.State)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Country)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Phone)
            .IsUnicode(false);

        modelBuilder.Entity<Manufacturer>()
            .Property(e => e.Email)
            .IsUnicode(false);

        modelBuilder.Entity<OrderDetail>()
             .Property(e => e.PaymentMode)
             .IsUnicode(false);

        modelBuilder.Entity<OrdersMaster>()
            .Property(e => e.OrderStatus)
            .IsUnicode(false);

        modelBuilder.Entity<OrdersMaster>()
            .Property(e => e.PaymentMode)
            .IsUnicode(false);

        modelBuilder.Entity<PurchaseOrderMaster>()
            .Property(e => e.PurchaseOrderStatus)
            .IsUnicode(false);

        modelBuilder.Entity<PurchaseOrderMaster>()
            .Property(e => e.PaymentMode)
            .IsUnicode(false);

        modelBuilder.Entity<PurchaseOrderMaster>()
        .Property(e => e.PaymentStatus)
        .IsUnicode(false);

        modelBuilder.Entity<Retailer>()
        .Property(e => e.Firstname)
        .IsUnicode(false);

        modelBuilder.Entity<Retailer>()
        .Property(e => e.LastName)
        .IsUnicode(false);

        modelBuilder.Entity<Retailer>()
        .Property(e => e.email)
        .IsUnicode(false);

        modelBuilder.Entity<Retailer>()
        .Property(e => e.Contactnumber)
        .IsUnicode(false);

        modelBuilder.Entity<Retailer>()
        .Property(e => e.Address)
        .IsUnicode(false);
}
    }
}