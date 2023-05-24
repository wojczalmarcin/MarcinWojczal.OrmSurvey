namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The order.
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public virtual string CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public virtual int? EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public virtual DateTime? OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the required date.
        /// </summary>
        public virtual DateTime? RequiredDate { get; set; }

        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        public virtual DateTime? ShippedDate { get; set; }

        /// <summary>
        /// Gets or sets the shipper id.
        /// </summary>
        public virtual int? ShipperID { get; set; }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        public virtual decimal? Freight { get; set; }

        /// <summary>
        /// Gets or sets the ship name.
        /// </summary>
        public virtual string? ShipName { get; set; }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        public virtual string? ShipAddress { get; set; }

        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        public virtual string? ShipCity { get; set; }

        /// <summary>
        /// Gets or sets the ship region.
        /// </summary>
        public virtual string? ShipRegion { get; set; }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        public virtual string? ShipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        public virtual string? ShipCountry { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the shipper.
        /// </summary>
        public virtual Shipper Shipper { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
