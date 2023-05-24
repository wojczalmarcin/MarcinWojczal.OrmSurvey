using NHibernate.Criterion;

namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class TerritoryMapping : ClassMapping<Territory>
    {
        public TerritoryMapping()
        {
            Table("Territories");
            Id(x => x.Id, map => map.Column("TerritoryID"));
            ManyToOne(x => x.Region, map => map.Column("RegionID"));
            Bag(x => x.EmployeeTerritories, m => m.Key(k => k.Column("TerritoryID")), rel => rel.OneToMany());
            Bag(x => x.Employees, cm =>
            {
                cm.Table("EmployeeTerritories");
                cm.Key(k => k.Column("TerritoryID"));
            },
            map => map.ManyToMany(p => p.Column("EmployeeID")));
        }
    }
}
