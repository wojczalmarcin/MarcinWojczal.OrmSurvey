namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The demographic.
    /// </summary>
    public partial class Demography
    {
        /// <summary>
        /// Gets or sets the customer demography id.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the customer demographics.
        /// </summary>
        public virtual ICollection<CustomerDemography> CustomerDemographics { get; set; }
    }
}
