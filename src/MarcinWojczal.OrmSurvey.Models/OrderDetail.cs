namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The order detail.
    /// </summary>
    public partial class OrderDetail
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public virtual int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public virtual int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public virtual decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public virtual short Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        public virtual float Discount { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public virtual Product Product { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is OrderDetail detail &&
                   Order.Id == detail.Order.Id &&
                   Product.Id == detail.Product.Id &&
                   UnitPrice == detail.UnitPrice &&
                   Quantity == detail.Quantity &&
                   Discount == detail.Discount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Order.Id, Product.Id, UnitPrice, Quantity, Discount);
        }
    }
}
