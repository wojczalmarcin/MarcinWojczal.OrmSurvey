namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The customer demographic.
    /// </summary>
    public partial class CustomerDemography
    {
        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public virtual string CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the demographic id.
        /// </summary>
        public virtual string DemographyID { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the demographic.
        /// </summary>
        public virtual Demography Demography { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CustomerDemography demography &&
                   CustomerID == demography.CustomerID &&
                   DemographyID == demography.DemographyID &&
                   EqualityComparer<Customer>.Default.Equals(Customer, demography.Customer) &&
                   EqualityComparer<Demography>.Default.Equals(Demography, demography.Demography);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerID, DemographyID, Customer, Demography);
        }
    }
}
