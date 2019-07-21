// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBusinessService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessManager.Interface;
    using CommonLayer.Model;
    using RepositoryManager.Interface;

    /// <summary>
    /// 
    /// </summary>
    public class EmployeeBusinessService : IEmployeeBusinessManager
    {
        public IEmployeeRepository repository;
        public EmployeeBusinessService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// AddEmployee method is for adding the new Employee in the list 
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public void AddEmployee(EmployeeModel employeeModel)
        {
            this.repository.AddEmployee(employeeModel);
         //   return 0;
        }

        public bool DeleteEmployee(int id)
        {
            return this.repository.DeleteEmployee(id);
        }
        public IList<EmployeeModel> DisplayEmployee()
        {
            return this.repository.DisplayEmployee();
        }

        public bool UpdateEmployee(EmployeeModel employeeModel, int id)
        {
            return this.repository.UpdateEmployee(employeeModel, id);
        }
    }
}
