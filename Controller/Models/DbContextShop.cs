using Controller.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBanQuanAo.Models
{
    public class DbContextShop : DbContext
    {
        public DbContextShop(DbContextOptions<DbContextShop> options) : base(options) { }
        public DbContextShop() { }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ProductDetailColor> ProductDetailColor { get; set; }
        public DbSet<ProductDetailSize> ProductDetailSize { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Bill
            modelBuilder.Entity<Bill>()
                .Property(b => b.SoTienMat)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Bill>()
                .Property(b => b.ThanhTien)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Bill>()
                .Property(b => b.TienChuyenKhoan)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Bill>()
                .Property(b => b.TienVanChuyen)
                .HasColumnType("decimal(18, 2)");

            // Configure BillDetail
            modelBuilder.Entity<BillDetail>()
                .Property(bd => bd.DonGia)
                .HasColumnType("decimal(18, 2)");

            // Configure CartDetail
            modelBuilder.Entity<CartDetail>()
                .Property(cd => cd.DonGia)
                .HasColumnType("decimal(18, 2)");

            // Configure Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Gia)
                .HasColumnType("decimal(18, 2)");

            // Configure Voucher
            modelBuilder.Entity<Voucher>()
                .Property(v => v.GiaTri)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ProductImage>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductImages)
            .HasForeignKey(p => p.ProductId);
            // Bảng Product Detail (không có quan hệ với Manufacturer)
            modelBuilder.Entity<ProductDetail>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng Product Detail Color
            modelBuilder.Entity<ProductDetailColor>()
                .HasOne(p => p.ProductDetail)
                .WithMany(p => p.ProductDetailColors)
                .HasForeignKey(p => p.ProductDetailId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            modelBuilder.Entity<ProductDetailColor>()
                .HasOne(p => p.Color)
                .WithMany(p => p.ProductDetailColors)
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng Product Detail Size
            modelBuilder.Entity<ProductDetailSize>()
                .HasOne(p => p.ProductDetail)
                .WithMany(p => p.ProductDetailSizes)
                .HasForeignKey(p => p.ProductDetailId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            modelBuilder.Entity<ProductDetailSize>()
                .HasOne(p => p.Size)
                .WithMany(p => p.ProductDetailSizes)
                .HasForeignKey(p => p.SizeId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng Cart Detail
            modelBuilder.Entity<CartDetail>()
                .HasOne(p => p.ProductDetail)
                .WithMany(p => p.CartDetails)
                .HasForeignKey(p => p.ProductDetailId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            modelBuilder.Entity<CartDetail>()
                .HasOne(p => p.Cart)
                .WithMany(p => p.CartDetails)
                .HasForeignKey(p => p.CartId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng Bill Detail
            modelBuilder.Entity<BillDetail>()
                .HasOne(p => p.ProductDetail)
                .WithMany(p => p.BillDetails)
                .HasForeignKey(p => p.ProductDetailId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            modelBuilder.Entity<BillDetail>()
                .HasOne(p => p.Bill)
                .WithMany(p => p.BillDetails)
                .HasForeignKey(p => p.BillId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng Voucher
            modelBuilder.Entity<Voucher>()
                .HasMany(p => p.Bills)
                .WithOne(p => p.Voucher)
                .HasForeignKey(p => p.VoucherId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            // Bảng User
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);

                b.HasMany(u => u.Bills)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(p => p.Bills)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Vô hiệu hóa cascade delete

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Manufacturer) // Quan hệ với Manufacturer
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                 .HasOne(p => p.ProductType)  // Một Product có một ProductType
                 .WithMany(pt => pt.Products)
                 .HasForeignKey(p => p.ProductTypeId)
                 .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ 1-1 giữa Product và Material
            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Material) // Mỗi Product có một Material
                 .WithMany(m => m.Product) // Mỗi Material có nhiều Product
                 .HasForeignKey(p => p.MaterialId); // Khóa ngoại trong Product

            // Cấu hình mối quan hệ 1-1 giữa Customer và Cart
            modelBuilder.Entity<Cart>()
                .HasOne(p => p.Customers)
                .WithOne(m => m.Carts)
                .HasForeignKey<Cart>(p => p.CustomerId);

            modelBuilder.Entity<User>()
                .HasMany(r => r.Roles)
                .WithOne(u => u.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>()
                .HasMany(a => a.Addresses)
                .WithOne(c => c.Customers)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = "R1",
                Ten = "Admin",
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = "Active",
                UserId = null
            },
            new Role
            {
                Id = "R2",
                Ten = "Staff",
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = "Active",
                UserId = null
            });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "U1",
                Ma = "U001",
                Username = "admin",
                Password = "admin001",
                Email = "admin@gmail.com",
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = "Active",
                RoleId = "R1"
            },
            new User
            {
                Id = "U2",
                Ma = "U002",
                Username = "staff",
                Password = "staff001",
                Email = "staff@gmail.com",
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = "Active",
                RoleId = "R2"
            });
        }

    }
}

