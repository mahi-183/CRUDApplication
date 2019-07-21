// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    /// <summary>
    /// IEmployeeBusinessManager is 
    /// </summary>
    public interface IEmployeeBusinessManager
    {
        /// <summary>
        /// AddEmployee method declaration is for adding the new Employee in the list 
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        void AddEmployee(EmployeeModel employeeModel);

        /// <summary>
        /// DeleteEmployee method declaration is for Deleting the Employee data  
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        bool DeleteEmployee(int id);

        /// <summary>
        /// DisplayEmployee method declaration is for Displaying the Employee data  
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        IList<EmployeeModel> DisplayEmployee();
        
        /// <summary>
        /// UpdateEmployee method declaration is for update the new Employee data 
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        bool UpdateEmployee(EmployeeModel employeeModel, int id);

    }
}
