namespace MarcinWojczal.OrmSurvey.NHibernate.Mapping
{
    internal class CategoryMapping : ClassMapping<Category>
    {
        public CategoryMapping() 
        {
            Table("Categories");
            Id(s => s.Id, im => { im.Generator(Generators.Identity); im.Column("CategoryID"); });
            Property(s => s.Description, pm => pm.NotNullable(false));
            Property(s => s.Picture, pm => pm.NotNullable(false));
            Bag(x => x.Products, m => m.Key(k => k.Column("CategoryID")), rel => rel.OneToMany());
        }
    }
}
