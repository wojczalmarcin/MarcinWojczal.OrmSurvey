namespace MarcinWojczal.OrmSurvey.EntityFramework.Mapping
{
    internal static class CategoryMapping
    {
        internal static ModelBuilder MapCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("CategoryID");
            modelBuilder.Entity<Category>().Property(x => x.Description).IsRequired(false);
            modelBuilder.Entity<Category>().Property(x => x.Picture).IsRequired(false);

            return modelBuilder;
        }
    }
}
