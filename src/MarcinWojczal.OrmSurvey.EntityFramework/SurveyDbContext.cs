using MarcinWojczal.OrmSurvey.EntityFramework.Mapping;

namespace MarcinWojczal.OrmSurvey.EntityFramework
{
    internal sealed class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCategory()
                .MapCustomer()
                .MapCustomerDemographics()
                .MapDemography()
                .MapEmployee()
                .MapEmployeeTerritory()
                .MapOrderDetail()
                .MapOrder()
                .MapProduct()
                .MapRegion()
                .MapShipper()
                .MapSupplier()
                .MapTerritory();
        }

        public DbSet<Order> Orders { get; set; }
    }
}
