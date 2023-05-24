namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class EmployeeMapping
    {
        internal static ModelBuilder MapEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().Property(x => x.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Employee>().HasOne(x => x.ReportsToEmployee).WithMany(x => x.ReportingEmployees).HasForeignKey("ReportsTo");
            modelBuilder.Entity<Employee>().HasMany(x => x.Territories).WithMany(x => x.Employees).UsingEntity<EmployeeTerritory>();
            modelBuilder.Entity<Employee>().Property(x => x.Title).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.TitleOfCourtesy).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.BirthDate).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.HireDate).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Address).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.City).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Region).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.PostalCode).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Country).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.HomePhone).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Extension).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Photo).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.Notes).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.ReportsTo).IsRequired(false);
            modelBuilder.Entity<Employee>().Property(x => x.PhotoPath).IsRequired(false);

            return modelBuilder;
        }
    }
}
