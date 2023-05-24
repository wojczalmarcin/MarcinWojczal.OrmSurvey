namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class DemographyMapping
    {
        internal static ModelBuilder MapDemography(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demography>().ToTable("CustomerDemographics");
            modelBuilder.Entity<Demography>().HasKey(x => x.Id);
            modelBuilder.Entity<Demography>().Property(x => x.Description).HasColumnName("CustomerDesc").IsRequired(false);
            modelBuilder.Entity<Demography>().Property(x => x.Id).HasColumnName("CustomerTypeID");

            return modelBuilder;
        }
    }
}
