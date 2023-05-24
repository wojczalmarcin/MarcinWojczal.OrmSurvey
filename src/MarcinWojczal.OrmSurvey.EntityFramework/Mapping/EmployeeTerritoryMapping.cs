namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class EmployeeTerritoryMapping
    {
        internal static ModelBuilder MapEmployeeTerritory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTerritory>().ToTable("EmployeeTerritories");
            modelBuilder.Entity<EmployeeTerritory>().HasKey(x => new { x.EmployeeID, x.TerritoryID });
            modelBuilder.Entity<EmployeeTerritory>().HasOne(x => x.Employee).WithMany(x => x.EmployeeTerritories).HasForeignKey("EmployeeID");
            modelBuilder.Entity<EmployeeTerritory>().HasOne(x => x.Territory).WithMany(x => x.EmployeeTerritories).HasForeignKey("TerritoryID");

            return modelBuilder;
        }
    }
}
