namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class OrderDetailMapping : ClassMapping<OrderDetail>
    {
        public OrderDetailMapping()
        {
            Table("[Order Details]");
            ComposedId(m =>
            {
                m.ManyToOne(x => x.Order, map => { map.Column("OrderID"); map.Insert(true); map.Update(true); map.NotNullable(true); map.Cascade(Cascade.DeleteOrphans); });
                m.ManyToOne(x => x.Product, map => { map.Column("ProductID"); map.Insert(true); map.Update(true); map.NotNullable(true); });
            });
            Property(x => x.Quantity);
            Property(x => x.Discount);
            Property(x => x.UnitPrice);
        }
    }
}
