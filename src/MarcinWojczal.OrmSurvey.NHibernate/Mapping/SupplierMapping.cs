namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class SupplierMapping : ClassMapping<Supplier>
    {
        public SupplierMapping()
        {
            Table("Suppliers");
            Id(x => x.Id, map => map.Column("SupplierID"));
            Property(x => x.ContactName, pm => pm.NotNullable(false));
            Property(x => x.ContactTitle, pm => pm.NotNullable(false));
            Property(x => x.Address, pm => pm.NotNullable(false));
            Property(x => x.City, pm => pm.NotNullable(false));
            Property(x => x.Region, pm => pm.NotNullable(false));
            Property(x => x.PostalCode, pm => pm.NotNullable(false));
            Property(x => x.Country, pm => pm.NotNullable(false));
            Property(x => x.Phone, pm => pm.NotNullable(false));
            Property(x => x.Fax, pm => pm.NotNullable(false));
            Property(x => x.HomePage, pm => pm.NotNullable(false));
            Bag(x => x.Products, m => m.Key(k => k.Column("SupplierID")), rel => rel.OneToMany());
        }
    }
}
