namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class CustomersDemographicsMapping
    {
        internal static ModelBuilder MapCustomerDemographics(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDemography>().ToTable("CustomerCustomerDemo");
            modelBuilder.Entity<CustomerDemography>().HasKey(x => new { x.CustomerID, x.DemographyID });
            modelBuilder.Entity<CustomerDemography>().Property(x => x.DemographyID).HasColumnName("CustomerTypeId");
            modelBuilder.Entity<CustomerDemography>().HasOne(x => x.Customer).WithMany(x => x.CustomerDemographics).HasForeignKey("CustomerID");
            modelBuilder.Entity<CustomerDemography>().HasOne(x => x.Demography).WithMany(x => x.CustomerDemographics).HasConstraintName("DemographyID");

            return modelBuilder;
        }
    }
}
