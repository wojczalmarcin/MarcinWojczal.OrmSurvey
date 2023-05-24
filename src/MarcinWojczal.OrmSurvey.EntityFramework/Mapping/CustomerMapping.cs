namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class CustomerMapping
    {
        internal static ModelBuilder MapCustomer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Id).HasColumnName("CustomerID");
            modelBuilder.Entity<Customer>().Property(x => x.ContactName).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.ContactTitle).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.Address).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.City).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.Region).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.PostalCode).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.Country).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.Phone).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(x => x.Fax).IsRequired(false);
             
            return modelBuilder;
        }
    }
}
