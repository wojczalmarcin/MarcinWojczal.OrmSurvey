namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The category.
    /// </summary>
    public partial class Category
    {
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public virtual byte[] Picture { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
