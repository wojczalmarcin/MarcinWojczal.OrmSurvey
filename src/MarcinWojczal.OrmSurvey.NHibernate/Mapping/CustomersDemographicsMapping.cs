namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class CustomersDemographicsMapping : ClassMapping<CustomerDemography>
    {
        public CustomersDemographicsMapping()
        {
            Table("CustomerCustomerDemo");
            ComposedId(m =>
            {
                m.ManyToOne(x => x.Customer, map => { map.Column("CustomerID");});
                m.ManyToOne(x => x.Demography, map => { map.Column("CustomerTypeID");});
            });
        }
    }
}
