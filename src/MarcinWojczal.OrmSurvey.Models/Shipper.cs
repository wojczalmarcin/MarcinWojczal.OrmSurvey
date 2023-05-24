namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The shipper.
    /// </summary>
    public partial class Shipper
    {
        /// <summary>
        /// Gets or sets the shipper id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public virtual string Phone { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
