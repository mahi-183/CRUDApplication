// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CommonLayer.Model
{
    //using System.ComponentModel.DataAnnotation;
    using System.ComponentModel;
    /// <summary>
    /// EmployeeModel class is for set and get employee data 
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        /// <value>
        /// The EmployeeId.
        /// </value>  
        [Required(ErrorMessage = "Enter Name")]
        public int EmployeeId
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        /// <value>
        /// The FirstName.
        /// </value>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        /// <value>
        /// The LastName.
        /// </value>
        public string LastName
        {
            get ; 
            set ; 
        }

        /// <summary>
        /// Gets or sets the Designation.
        /// </summary>
        /// <value>
        /// The Designation.
        /// </value>
        public string Designation
        {
        get;
            set; 
        }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>
        /// The Salary.
        /// </value>
        public int Salary
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        /// <value>
        /// The Age.
        /// </value>
        public int Age
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>
        /// The Gender.
        /// </value>
        public string Gender
        {
            get;
            set;
        }
    }
}

