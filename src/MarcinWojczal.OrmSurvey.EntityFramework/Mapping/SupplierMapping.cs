namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class SupplierMapping
    {
        internal static ModelBuilder MapSupplier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supplier>().HasKey(x => x.Id);
            modelBuilder.Entity<Supplier>().Property(x => x.Id).HasColumnName("SupplierID");
            modelBuilder.Entity<Supplier>().Property(x => x.ContactName).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.ContactTitle).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.Address).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.City).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.Region).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.PostalCode).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.Country).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.Phone).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.Fax).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(x => x.HomePage).IsRequired(false);

            return modelBuilder;
        }
    }
}
