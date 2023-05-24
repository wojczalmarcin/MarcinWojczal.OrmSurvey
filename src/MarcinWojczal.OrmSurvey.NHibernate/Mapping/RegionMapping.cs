namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class RegionMapping : ClassMapping<Region>
    {
        public RegionMapping()
        {
            Table("Region");
            Id(x => x.Id, map => { map.Column("RegionID"); map.Generator(Generators.Assigned); });
            Bag(x => x.Territories, m => m.Key(k => k.Column("RegionID")), rel => rel.OneToMany());
        }
    }
}
