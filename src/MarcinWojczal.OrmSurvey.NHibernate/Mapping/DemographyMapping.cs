namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class DemographyMapping : ClassMapping<Demography>
    {
        public DemographyMapping()
        {
            Table("CustomerDemographics");
            Id(x => x.Id, map => map.Column("CustomerTypeID"));
            Property(x => x.Description, map =>
            {
                map.Column("CustomerDesc");
                map.NotNullable(true);
            });
            Bag(x => x.CustomerDemographics, m => m.Key(k => k.Column("CustomerTypeID")), rel => rel.OneToMany());
        }
    }
}
