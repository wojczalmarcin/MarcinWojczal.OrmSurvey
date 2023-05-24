namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class ShipperMapping
    {
        internal static ModelBuilder MapShipper(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipper>().ToTable("Shippers");
            modelBuilder.Entity<Shipper>().HasKey(x => x.Id);
            modelBuilder.Entity<Shipper>().Property(x => x.Id).HasColumnName("ShipperID");
            modelBuilder.Entity<Shipper>().Property(x => x.Phone).IsRequired(false);

            return modelBuilder;
        }
    }
}
