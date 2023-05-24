namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping()
        {
            Table("Products");
            Id(x => x.Id, map => map.Column("ProductID"));
            ManyToOne(x => x.Category);
            ManyToOne(x => x.Supplier);
            Property(x => x.SupplierID, pm => pm.NotNullable(false));
            Property(x => x.CategoryID, pm => pm.NotNullable(false));
            Property(x => x.QuantityPerUnit, pm => pm.NotNullable(false));
            Property(x => x.UnitPrice, pm => pm.NotNullable(false));
            Property(x => x.UnitsInStock, pm => pm.NotNullable(false));
            Property(x => x.UnitsOnOrder, pm => pm.NotNullable(false));
            Property(x => x.ReorderLevel, pm => pm.NotNullable(false));
            Bag(x => x.OrderDetails, m => m.Key(k => k.Column("ProductID")), rel => rel.OneToMany());
        }
    }
}
