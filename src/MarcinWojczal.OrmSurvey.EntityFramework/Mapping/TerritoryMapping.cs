namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class TerritoryMapping
    {
        internal static ModelBuilder MapTerritory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Territory>().ToTable("Territories");
            modelBuilder.Entity<Territory>().HasKey(x => x.Id);
            modelBuilder.Entity<Territory>().Property(x => x.Id).HasColumnName("TerritoryID");
            modelBuilder.Entity<Territory>().HasOne(x => x.Region).WithMany(x => x.Territories).HasForeignKey("RegionID");

            return modelBuilder;
        }
    }
}
