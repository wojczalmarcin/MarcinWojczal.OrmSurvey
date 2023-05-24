namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class EmployeeTerritoryMapping : ClassMapping<EmployeeTerritory>
    {
        public EmployeeTerritoryMapping()
        {
            Table("EmployeeTerritories");
            Id(x => x.EmployeeID);
            Id(x => x.TerritoryID);
            ManyToOne(x => x.Employee, map => { map.Column("EmployeeID"); map.Insert(false); map.Update(false); });
            ManyToOne(x => x.Territory, map => { map.Column("TerritoryID"); map.Insert(false); map.Update(false); });
        }
    }
}
