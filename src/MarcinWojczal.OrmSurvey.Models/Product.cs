namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The product.
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public virtual string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        public virtual int? SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public virtual int? CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the quantity per unit.
        /// </summary>
        public virtual string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public virtual decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the units in stock.
        /// </summary>
        public virtual short? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the units on order.
        /// </summary>
        public virtual short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        public virtual short? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether discontinued.
        /// </summary>
        public virtual bool Discontinued { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
