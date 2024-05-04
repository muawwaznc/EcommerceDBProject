using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDBProject.NewDatabase;

public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<InventoryItemPicture> InventoryItemPictures { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPromotion> ProductPromotions { get; set; }

    public virtual DbSet<ProductReturn> ProductReturns { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFOFFG3\\SQLEXPRESS;Initial Catalog=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2A1B729DBEB6");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('ADD-'+CONVERT([varchar](10),NEXT VALUE FOR [AddressIDSequence]))")
                .HasColumnName("AddressID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("PK__Customer__564F56D21C57B035");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerId, "UQ__Customer__A4AE64B92996154A").IsUnique();

            entity.Property(e => e.UserDetailId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UserDetailID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('CUS-'+CONVERT([varchar](10),NEXT VALUE FOR [CustomerIDSequence]))")
                .HasColumnName("CustomerID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.UserDetail).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_UserDetails");
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => new { e.SellerId, e.ProductId });

            entity.ToTable("InventoryItem");

            entity.HasIndex(e => e.InventoryItemId, "UQ__Inventor__3BB2ACA12D8E1F05").IsUnique();

            entity.Property(e => e.SellerId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SellerID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ProductID");
            entity.Property(e => e.Condition)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("New");
            entity.Property(e => e.InventoryItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('INVITM-'+CONVERT([varchar](10),NEXT VALUE FOR [InventoryItemIDSequence]))")
                .HasColumnName("InventoryItemID");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItem_Product");

            entity.HasOne(d => d.Seller).WithMany(p => p.InventoryItems)
                .HasPrincipalKey(p => p.SellerId)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItem_Seller");
        });

        modelBuilder.Entity<InventoryItemPicture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__Inventor__8C2866F8BC274D1E");

            entity.Property(e => e.PictureId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('ITMPIC-'+CONVERT([varchar](10),NEXT VALUE FOR [PictureIDSequence]))")
                .HasColumnName("PictureID");
            entity.Property(e => e.InventoryItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("InventoryItemID");
            entity.Property(e => e.PictureUrl)
                .IsUnicode(false)
                .HasColumnName("PictureURL");

            entity.HasOne(d => d.InventoryItem).WithMany(p => p.InventoryItemPictures)
                .HasPrincipalKey(p => p.InventoryItemId)
                .HasForeignKey(d => d.InventoryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItemPictue_InventoryItem");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFF12F7B41");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('ORD-'+CONVERT([varchar](10),NEXT VALUE FOR [OrderIDSequence]))")
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddressId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ShippingAddressID");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasPrincipalKey(p => p.CustomerId)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ShippingAddress");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.InventoryItemId });

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderItemId, "UQ__OrderIte__57ED06A0379D7D84").IsUnique();

            entity.Property(e => e.OrderId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.InventoryItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("InventoryItemID");
            entity.Property(e => e.OrderItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('ORDITM-'+CONVERT([varchar](10),NEXT VALUE FOR [OrderItemIDSequence]))")
                .HasColumnName("OrderItemID");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequiredShippingDate)
                .HasDefaultValueSql("(dateadd(day,(7),getdate()))")
                .HasColumnType("datetime");
            entity.Property(e => e.ShippingDate).HasColumnType("datetime");

            entity.HasOne(d => d.InventoryItem).WithMany(p => p.OrderItems)
                .HasPrincipalKey(p => p.InventoryItemId)
                .HasForeignKey(d => d.InventoryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_InventoryItem");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDF3E3FF6D");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('PROD-'+CONVERT([varchar](10),NEXT VALUE FOR [ProductIDSequence]))")
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SupplierID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasPrincipalKey(p => p.SupplierId)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Product_Supplier");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProductC__19093A2B14E76B7D");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('CAT-'+CONVERT([varchar](10),NEXT VALUE FOR [CategoryIDSequence]))")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription).HasColumnType("text");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductPromotion>(entity =>
        {
            entity.HasKey(e => new { e.PromotionId, e.InventoryItemId });

            entity.ToTable("ProductPromotion");

            entity.HasIndex(e => e.ProductPromotionId, "UQ__ProductP__9E52FB229D63DF13").IsUnique();

            entity.Property(e => e.PromotionId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PromotionID");
            entity.Property(e => e.InventoryItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("InventoryItemID");
            entity.Property(e => e.ProductPromotionId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('PR_PROM-'+CONVERT([varchar](10),NEXT VALUE FOR [ProductPromotionIDSequence]))")
                .HasColumnName("ProductPromotionID");

            entity.HasOne(d => d.InventoryItem).WithMany(p => p.ProductPromotions)
                .HasPrincipalKey(p => p.InventoryItemId)
                .HasForeignKey(d => d.InventoryItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPromotion_InventoryItem");

            entity.HasOne(d => d.Promotion).WithMany(p => p.ProductPromotions)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPromotion_Promotion");
        });

        modelBuilder.Entity<ProductReturn>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__ProductR__57ED06A13B12F17D");

            entity.ToTable("ProductReturn");

            entity.HasIndex(e => e.ReturnId, "UQ__ProductR__F445E98981F7FAA7").IsUnique();

            entity.Property(e => e.OrderItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OrderItemID");
            entity.Property(e => e.ReturnDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReturnId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('RET-'+CONVERT([varchar](10),NEXT VALUE FOR [ReturnIDSequence]))")
                .HasColumnName("ReturnID");
            entity.Property(e => e.ReturnReason).HasColumnType("text");
            entity.Property(e => e.ReturnStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.OrderItem).WithOne(p => p.ProductReturn)
                .HasPrincipalKey<OrderItem>(p => p.OrderItemId)
                .HasForeignKey<ProductReturn>(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReturn_OrderItem");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__ProductR__57ED06A1445D80CA");

            entity.HasIndex(e => e.ReviewId, "UQ__ProductR__74BC79AF584834E5").IsUnique();

            entity.Property(e => e.OrderItemId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OrderItemID");
            entity.Property(e => e.Rating).HasDefaultValue(0);
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('REV-'+CONVERT([varchar](10),NEXT VALUE FOR [ReviewIDSequence]))")
                .HasColumnName("ReviewID");
            entity.Property(e => e.ReviewText).HasColumnType("text");

            entity.HasOne(d => d.OrderItem).WithOne(p => p.ProductReview)
                .HasPrincipalKey<OrderItem>(p => p.OrderItemId)
                .HasForeignKey<ProductReview>(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReviews_OrderItem");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2F2BC7A878");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('PROM-'+CONVERT([varchar](10),NEXT VALUE FOR [PromotionIDSequence]))")
                .HasColumnName("PromotionID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PromotionDescription).HasColumnType("text");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("PK__Seller__564F56D2C2A6CF9D");

            entity.ToTable("Seller");

            entity.HasIndex(e => e.SellerId, "UQ__Seller__7FE3DBA0609CD929").IsUnique();

            entity.Property(e => e.UserDetailId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UserDetailID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SellerId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('SEL-'+CONVERT([varchar](10),NEXT VALUE FOR [SellerIDSequence]))")
                .HasColumnName("SellerID");
            entity.Property(e => e.SellerRating).HasDefaultValue(0);

            entity.HasOne(d => d.UserDetail).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_UserDetails");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("PK__Supplier__564F56D28C7D127B");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.SupplierId, "UQ__Supplier__4BE666951C1EE6B1").IsUnique();

            entity.Property(e => e.UserDetailId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UserDetailID");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('SUP-'+CONVERT([varchar](10),NEXT VALUE FOR [SupplierIDSequence]))")
                .HasColumnName("SupplierID");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.UserDetail).WithOne(p => p.Supplier)
                .HasForeignKey<Supplier>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_UserDetails");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("PK__UserDeta__564F56D22613580E");

            entity.HasIndex(e => e.PhoneNumber, "UQ__UserDeta__85FB4E38DE3F02AC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserDeta__A9D105341FC67E9A").IsUnique();

            entity.Property(e => e.UserDetailId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('USERDET-'+CONVERT([varchar](10),NEXT VALUE FOR [UserDetailIDSequence]))")
                .HasColumnName("UserDetailID");
            entity.Property(e => e.AddressId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("AddressID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Picture).IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_UserDetails_Address");
        });
        modelBuilder.HasSequence("AddressIDSequence");
        modelBuilder.HasSequence("CategoryIDSequence");
        modelBuilder.HasSequence("CustomerIDSequence");
        modelBuilder.HasSequence("InventoryItemIDSequence");
        modelBuilder.HasSequence("OrderIDSequence");
        modelBuilder.HasSequence("OrderItemIDSequence");
        modelBuilder.HasSequence("PictureIDSequence");
        modelBuilder.HasSequence("ProductIDSequence");
        modelBuilder.HasSequence("ProductPromotionIDSequence");
        modelBuilder.HasSequence("PromotionIDSequence");
        modelBuilder.HasSequence("ReturnIDSequence");
        modelBuilder.HasSequence("ReviewIDSequence");
        modelBuilder.HasSequence("SellerIDSequence");
        modelBuilder.HasSequence("SupplierIDSequence");
        modelBuilder.HasSequence("UserDetailIDSequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
