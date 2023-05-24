namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class OrderDetailMapping
    {
        internal static ModelBuilder MapOrderDetail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");
            modelBuilder.Entity<OrderDetail>().HasKey(x => new {x.OrderID, x.ProductID});
            modelBuilder.Entity<OrderDetail>().Property(x => x.OrderID).ValueGeneratedNever();
            modelBuilder.Entity<OrderDetail>().Property(x => x.ProductID).ValueGeneratedNever();
            modelBuilder.Entity<OrderDetail>().HasOne(x => x.Order).WithMany(x => x.OrderDetails);
            modelBuilder.Entity<OrderDetail>().HasOne(x => x.Product).WithMany(x => x.OrderDetails);

            return modelBuilder;
        }
    }
}
