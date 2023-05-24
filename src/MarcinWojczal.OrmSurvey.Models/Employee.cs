namespace MarcinWojczal.OrmSurvey.Models
{
    /// <summary>
    /// The employee.
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the title of courtesy.
        /// </summary>
        public virtual string TitleOfCourtesy { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        public virtual DateTime? HireDate { get; set; }

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
        /// Gets or sets the home phone.
        /// </summary>
        public virtual string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        public virtual string Extension { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        public virtual byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        public virtual int? ReportsTo { get; set; }

        /// <summary>
        /// Gets or sets the photo path.
        /// </summary>
        public virtual string PhotoPath { get; set; }

        /// <summary>
        /// Gets or sets the reports to employee.
        /// </summary>
        public virtual Employee ReportsToEmployee { get; set; }

        /// <summary>
        /// Gets or sets the territories.
        /// </summary>
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

        /// <summary>
        /// Gets or sets the terretories
        /// </summary>
        public virtual ICollection<Territory> Territories { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the reporting employees.
        /// </summary>
        public virtual ICollection<Employee> ReportingEmployees { get; set; }
    }
}
