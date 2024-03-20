using CandyShop_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CandyShop_API.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        #region DBSet

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // category table
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(cate => cate.idCate);
                entity.Property(cate => cate.idCate).ValueGeneratedOnAdd();
            });

            // product table
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(pro => pro.idPro);
                entity.HasOne(pro => pro.category)
                .WithMany(cate => cate.products)
                .HasForeignKey(pro => pro.idCate)
                .HasConstraintName("FK_Products_Category"); ;
            });

            // image table
            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");
                entity.HasKey(pro => pro.idImg);
                entity.HasOne(img => img.product)
                .WithMany(pro => pro.images)
                .HasForeignKey(img => img.idPro)
                .HasConstraintName("FK_Images_Product"); 
            });
        }
    }
}
