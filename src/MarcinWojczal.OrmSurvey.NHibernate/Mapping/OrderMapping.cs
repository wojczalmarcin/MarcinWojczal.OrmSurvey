namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("Orders");
            Id(x => x.Id, map => { map.Column("OrderID"); map.Generator(Generators.Identity); });
            ManyToOne(x => x.Customer, map => { map.Column("CustomerID"); map.Insert(false); map.Update(false); map.Cascade(Cascade.None); });
            ManyToOne(x => x.Employee, map => { map.Column("EmployeeID"); map.Insert(false); map.Update(false); map.Cascade(Cascade.None); });
            ManyToOne(x => x.Shipper, map =>{ map.Column("ShipVia"); map.Insert(false); map.Update(false); map.Cascade(Cascade.None); });
            Property(x => x.ShipRegion, pm => pm.NotNullable(false));
            Property(x => x.ShipPostalCode, pm => pm.NotNullable(false));
            Set(x => x.OrderDetails, m => { m.Key(k => k.Column("OrderID")); m.Inverse(true); m.Cascade(Cascade.DeleteOrphans);}, rel => rel.OneToMany());
            Property(x => x.OrderDate);
            Property(x => x.RequiredDate);
            Property(x => x.ShippedDate);
            Property(x => x.Freight);
            Property(x => x.ShipName);
            Property(x => x.ShipAddress);
            Property(x => x.ShipCity);
            Property(x => x.ShipCountry);
            Property(x => x.ShipperID, map => map.Column("ShipVia"));
            Property(x => x.CustomerID);
            Property(x => x.EmployeeID);
        }
    }
}