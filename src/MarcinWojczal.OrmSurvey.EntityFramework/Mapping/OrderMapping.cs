namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class OrderMapping
    {
        internal static ModelBuilder MapOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("OrderID");
            modelBuilder.Entity<Order>().HasOne(x => x.Customer).WithMany(x => x.Orders);
            modelBuilder.Entity<Order>().HasOne(x => x.Employee).WithMany(x => x.Orders);
            modelBuilder.Entity<Order>().HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey("ShipperID");
            modelBuilder.Entity<Order>().Property(x => x.ShipperID).HasColumnName("ShipVia");
            modelBuilder.Entity<Order>().Property(x => x.OrderDate).HasColumnType("datetime");

            return modelBuilder;
        }
    }
}
