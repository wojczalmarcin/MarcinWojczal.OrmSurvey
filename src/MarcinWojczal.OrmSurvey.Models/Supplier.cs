namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The supplier.
    /// </summary>
    public partial class Supplier
    {
        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the contact name.
        /// </summary>
        public virtual string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        public virtual string ContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public virtual string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public virtual string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        public virtual string Fax { get; set; }

        /// <summary>
        /// Gets or sets the home page.
        /// </summary>
        public virtual string HomePage { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
