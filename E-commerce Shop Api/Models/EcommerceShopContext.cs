using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_Shop_Api.Models;

public partial class EcommerceShopContext : DbContext
{
    public EcommerceShopContext()
    {
    }

    public EcommerceShopContext(DbContextOptions<EcommerceShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddCategory> AddCategories { get; set; }

    public virtual DbSet<AddProduct> AddProducts { get; set; }

    public virtual DbSet<AddProductsale> AddProductsales { get; set; }

    public virtual DbSet<Addtocart> Addtocarts { get; set; }

    public virtual DbSet<Adminlogin> Adminlogins { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Register> Registers { get; set; }
    ///...../
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KHBGNKV\\SQLEXPRESS;Database=ecommerce_shop;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddCategory>(entity =>
        {
            entity.ToTable("addCategories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<AddProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("addProducts");

            entity.HasIndex(e => e.CategoryList, "IX_addProducts_category_list");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.CategoryList).HasColumnName("category_list");
            entity.Property(e => e.ProductDetails).HasColumnName("Product_Details");
            entity.Property(e => e.ProductImages).HasColumnName("Product_Images");
            entity.Property(e => e.ProductName).HasColumnName("Product_Name");
            entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

            entity.HasOne(d => d.CategoryListNavigation).WithMany(p => p.AddProducts).HasForeignKey(d => d.CategoryList);
        });

        modelBuilder.Entity<AddProductsale>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("addProductsales");

            entity.HasIndex(e => e.CategoryList, "IX_addProductsales_category_list");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.CategoryList).HasColumnName("category_list");
            entity.Property(e => e.ProductDetails).HasColumnName("Product_Details");
            entity.Property(e => e.ProductImages).HasColumnName("Product_Images");
            entity.Property(e => e.ProductName).HasColumnName("Product_Name");
            entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

            entity.HasOne(d => d.CategoryListNavigation).WithMany(p => p.AddProductsales).HasForeignKey(d => d.CategoryList);
        });

        modelBuilder.Entity<Addtocart>(entity =>
        {
            entity.ToTable("Addtocart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductDetails).HasColumnName("Product_Details");
            entity.Property(e => e.ProductImages).HasColumnName("Product_Images");
            entity.Property(e => e.ProductName).HasColumnName("Product_Name");
            entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");
        });

        modelBuilder.Entity<Adminlogin>(entity =>
        {
            entity.ToTable("adminlogins");

            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("feedbacks");
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.ToTable("registers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    //
}
