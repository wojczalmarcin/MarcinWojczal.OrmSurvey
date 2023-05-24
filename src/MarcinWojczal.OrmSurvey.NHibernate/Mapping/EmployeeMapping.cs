namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class EmployeeMapping : ClassMapping<Employee>
    {
        public EmployeeMapping()
        {
            Table("Employees");
            Id(x => x.Id, map => map.Column("EmployeeID"));
            ManyToOne(x => x.ReportsToEmployee, map => { map.Column("ReportsTo"); map.NotNullable(false); });
            Property(x => x.Title, pm => pm.NotNullable(false));
            Property(x => x.TitleOfCourtesy, pm => pm.NotNullable(false));
            Property(x => x.BirthDate, pm => pm.NotNullable(false));
            Property(x => x.HireDate, pm => pm.NotNullable(false));
            Property(x => x.Address, pm => pm.NotNullable(false));
            Property(x => x.City, pm => pm.NotNullable(false));
            Property(x => x.Region, pm => pm.NotNullable(false));
            Property(x => x.PostalCode, pm => pm.NotNullable(false));
            Property(x => x.Country, pm => pm.NotNullable(false));
            Property(x => x.HomePhone, pm => pm.NotNullable(false));
            Property(x => x.Extension, pm => pm.NotNullable(false));
            Property(x => x.Photo, pm => pm.NotNullable(false));
            Property(x => x.Notes, pm => pm.NotNullable(false));
            Property(x => x.PhotoPath, pm => pm.NotNullable(false));
            Bag(x => x.ReportingEmployees, m => m.Key(k => k.Column("ReportsTo")), rel => rel.OneToMany());
            Bag(x => x.EmployeeTerritories, m => m.Key(k => k.Column("EmployeeID")), rel => rel.OneToMany());
            Bag(x => x.Orders, m => m.Key(k => k.Column("EmployeeID")), rel => rel.OneToMany());
            Bag(x => x.Territories, cm =>
            {
                cm.Table("EmployeeTerritories");
                cm.Key(k => k.Column("EmployeeID"));
            },
            map => map.ManyToMany(p => p.Column("TerritoryID")));
        }
    }
}
