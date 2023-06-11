using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Models;

public partial class MarketPlaceDbContext : DbContext
{
    public MarketPlaceDbContext()
    {
    }

    public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllProduct> AllProducts { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<BuyerMedal> BuyerMedals { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartProduct> CartProducts { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<MothersCategory> MothersCategorys { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<SellerInformation> SellerInformations { get; set; }

    public virtual DbSet<SellerMedal> SellerMedals { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Data Source=ASHKANR2-PC2017\\ASHKAN_MAKTAB;Initial Catalog=MarketPlaceDb;TrustServerCertificate=True;Integrated Security=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllProduct>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_AllProducts_CategoryId");

            entity.Property(e => e.Name).HasMaxLength(35);

            entity.HasOne(d => d.Category).WithMany(p => p.AllProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllProducts_Categorys");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");

            entity.ToTable("AppUser");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.BuyerMedalId, "IX_AspNetUsers_BuyerMedalId");

            entity.HasIndex(e => e.UserProfileImageId, "IX_AspNetUsers_UserProfileImageId");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex1")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.CountOfBuy).HasMaxLength(10);
            entity.Property(e => e.CreatAt).HasColumnName("CreatAT");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LastName).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Name).HasDefaultValueSql("(N'')");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.BuyerMedal).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.BuyerMedalId)
                .HasConstraintName("FK_AspNetUsers_BuyerMedals");

            entity.HasOne(d => d.UserProfileImage).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.UserProfileImageId)
                .HasConstraintName("FK_AspNetUsers_Images");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AppUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_Auctions_ProductId");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auctions_Products");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasIndex(e => e.AuctionId, "IX_Bids_AuctionId");

            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Auctions");
        });

        modelBuilder.Entity<Booth>(entity =>
        {
            entity.ToTable("Booth");

            entity.HasIndex(e => e.BoothImageId, "IX_Booth_BoothImageId");

            entity.HasIndex(e => e.CityId, "IX_Booth_CityId");

            entity.HasIndex(e => e.OwnerUserId, "IX_Booth_OwnerUserId");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.BoothImage).WithMany(p => p.Booths)
                .HasForeignKey(d => d.BoothImageId)
                .HasConstraintName("FK_Booth_Images");

            entity.HasOne(d => d.City).WithMany(p => p.Booths)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Cities");

            entity.HasOne(d => d.OwnerUser).WithMany(p => p.Booths)
                .HasForeignKey(d => d.OwnerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_AspNetUsers");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasIndex(e => e.BoothId, "IX_Carts_BoothId");

            entity.HasIndex(e => e.UserId, "IX_Carts_UserId");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Booth).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Booth");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_AppUser");
        });

        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.HasIndex(e => e.CartId, "IX_CartProducts_CartId");

            entity.HasIndex(e => e.ProductId, "IX_CartProducts_ProductId");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartProducts_Carts");

            entity.HasOne(d => d.Product).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartProducts_Products");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category");

            entity.HasIndex(e => e.MotherCategoryId, "IX_Categorys_MotherCategoryId");

            entity.Property(e => e.Title).HasMaxLength(25);

            entity.HasOne(d => d.MotherCategory).WithMany(p => p.Categories)
                .HasForeignKey(d => d.MotherCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categorys_MothersCategorys");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasIndex(e => e.ProvincesId, "IX_Cities_ProvincesId");

            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Provinces).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvincesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_provinces");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.BoothId, "IX_Comments_BoothId");

            entity.HasIndex(e => e.OrderId, "IX_Comments_OrderId");

            entity.HasIndex(e => e.UserId, "IX_Comments_User_Id");

            entity.Property(e => e.Comment1)
                .HasMaxLength(250)
                .HasColumnName("comment");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Booth).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Booth");

            entity.HasOne(d => d.Order).WithMany(p => p.Comments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Orders");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_AspNetUsers");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Path).HasMaxLength(30);
        });

        modelBuilder.Entity<MothersCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MothersCategory");

            entity.Property(e => e.Title).HasMaxLength(25);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.BoothId, "IX_Orders_BoothId");

            entity.HasIndex(e => e.StatusId, "IX_Orders_StatusId");

            entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

            entity.HasOne(d => d.Booth).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Booth");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Status");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_AspNetUsers");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderProducts_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderProducts_ProductId");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProducts_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProducts_Products1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.AllProductId, "IX_Products_AllProductId");

            entity.Property(e => e.IsAvailable)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.AllProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.AllProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_AllProducts");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasIndex(e => e.ImageId, "IX_ProductImages_ImageId");

            entity.HasIndex(e => e.ProductId, "IX_ProductImages_ProductId");

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Images");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.ToTable("provinces");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<SellerInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SellerInformation_1");

            entity.ToTable("SellerInformation");

            entity.HasIndex(e => e.CityId, "IX_SellerInformation_CityId");

            entity.HasIndex(e => e.SellerMedalId, "IX_SellerInformation_SellerMedalID");

            entity.HasIndex(e => e.UserId, "IX_SellerInformation_UserId");

            entity.Property(e => e.NationalCode).HasMaxLength(10);
            entity.Property(e => e.SellerMedalId).HasColumnName("SellerMedalID");

            entity.HasOne(d => d.City).WithMany(p => p.SellerInformations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellerInformation_Cities");

            entity.HasOne(d => d.SellerMedal).WithMany(p => p.SellerInformations)
                .HasForeignKey(d => d.SellerMedalId)
                .HasConstraintName("FK_SellerInformation_SellerMedals");

            entity.HasOne(d => d.User).WithMany(p => p.SellerInformations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SellerInformation_AspNetUsers");
        });

        modelBuilder.Entity<SellerMedal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medals");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
