namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class CustomerMapping : ClassMapping<Customer>
    {
        public CustomerMapping()
        {
            Table("Customers");
            Id(x => x.Id, im => { im.Generator(Generators.Identity); im.Column("CustomerID"); });
            Property(x => x.ContactName, pm => pm.NotNullable(false));
            Property(x => x.ContactTitle, pm => pm.NotNullable(false));
            Property(x => x.Address, pm => pm.NotNullable(false));
            Property(x => x.City, pm => pm.NotNullable(false));
            Property(x => x.Region, pm => pm.NotNullable(false));
            Property(x => x.PostalCode, pm => pm.NotNullable(false));
            Property(x => x.Country, pm => pm.NotNullable(false));
            Property(x => x.Phone, pm => pm.NotNullable(false));
            Property(x => x.Fax, pm => pm.NotNullable(false));
            Bag(x => x.CustomerDemographics, m => m.Key(k => k.Column("CustomerID")), rel => rel.OneToMany());
            Bag(x => x.Orders, m => m.Key(k => k.Column("CustomerID")), rel => rel.OneToMany());
        }
    }
}
