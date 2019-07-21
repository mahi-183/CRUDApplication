// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace EmployeeApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using BusinessManager.Interface;
    using CommonLayer.Model;
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeBusinessManager employeeBusinessManager;

        public EmployeeController(IEmployeeBusinessManager employeeBusinessManager)
        {
            this.employeeBusinessManager = employeeBusinessManager;
        }

        // GET: api/E
        [HttpGet]
        [Route("Get")]
        public IList<EmployeeModel> GetDetails()
        {
            return employeeBusinessManager.DisplayEmployee();
        }

        // POST: api/E
        [HttpPost]
        [Route("add")]
        public void Add(EmployeeModel employeeModel)
        {
            employeeBusinessManager.AddEmployee(employeeModel);
        }

        // PUT: api/Employee/update
        [HttpPut]
        [Route("update/{id}")]
        public void Put(EmployeeModel employeeModel, int id)
        {
            employeeBusinessManager.UpdateEmployee(employeeModel, id);
        }

        // DELETE: api/Employee/1
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            employeeBusinessManager.DeleteEmployee(id);
        }
    }
}
