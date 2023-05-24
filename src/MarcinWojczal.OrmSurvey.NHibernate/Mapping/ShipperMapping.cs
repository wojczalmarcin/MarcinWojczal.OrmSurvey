namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class ShipperMapping : ClassMapping<Shipper>
    {
        public ShipperMapping()
        {
            Table("Shippers");
            Id(x => x.Id, map => map.Column("ShipperID"));
            Property(x => x.Phone, pm => pm.NotNullable(false));
            Bag(x => x.Orders, m => m.Key(k => { k.Column("ShipVia"); }), rel => rel.OneToMany());
        }
    }
}
