namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The region.
    /// </summary>
    public partial class Region
    {
        /// <summary>
        /// Gets or sets the region id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the region description.
        /// </summary>
        public virtual string RegionDescription { get; set; }

        /// <summary>
        /// Gets or sets the territories.
        /// </summary>
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
