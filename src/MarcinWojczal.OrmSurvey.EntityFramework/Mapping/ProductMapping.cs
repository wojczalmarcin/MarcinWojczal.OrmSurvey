namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class ProductMapping
    {
        internal static ModelBuilder MapProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("ProductID");
            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey("CategoryID");
            modelBuilder.Entity<Product>().HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey("SupplierID");
            modelBuilder.Entity<Product>().Property(x => x.SupplierID).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.CategoryID).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.UnitsOnOrder).IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.ReorderLevel).IsRequired(false);

            return modelBuilder;
        }
    }
}
