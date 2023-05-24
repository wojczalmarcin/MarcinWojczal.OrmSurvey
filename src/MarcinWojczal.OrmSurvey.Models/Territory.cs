namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The territory.
    /// </summary>
    public partial class Territory
    {
        /// <summary>
        /// Gets or sets the territory id.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets the territory description.
        /// </summary>
        public virtual string TerritoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the region id.
        /// </summary>
        public virtual int RegionID { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public virtual Region Region { get; set; }

        /// <summary>
        /// Gets or sets the employee territories.
        /// </summary>
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
