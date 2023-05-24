namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class RegionMapping
    {
        internal static ModelBuilder MapRegion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Region>().HasKey(x => x.Id);
            modelBuilder.Entity<Region>().Property(x => x.Id).HasColumnName("RegionID");
            modelBuilder.Entity<Region>().Property(x => x.Id).ValueGeneratedNever();

            return modelBuilder;
        }
    }
}
