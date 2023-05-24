namespace MarcinWojczal.OrmSurvey.Models
{
    public partial class EmployeeTerritory
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public virtual int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the territory id.
        /// </summary>
        public virtual string TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Territory Territory { get; set; }
    }
}
