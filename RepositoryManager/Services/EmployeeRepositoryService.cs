// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRepositoryService.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryManager.Services
{
    using System;
    using System.Collections.Generic;
    using CommonLayer.Model;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Data;
    using RepositoryManager.Interface;
    using System.Data.SqlClient;

    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRepositoryService : IEmployeeRepository
    {
        private static object Configuaration;

        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-KOH93I0;Initial Catalog=EmployeeDb;Integrated Security=True");

        /// <summary>
        /// AddEmployee method is for adding the new Employee in the list 
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public int AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("[InsertEmployee]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@EmployeeId", 0);
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Designation", employeeModel.Designation);
                sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlCommand.Parameters.AddWithValue("@Age", employeeModel.Age);
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return 0;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("[DeleteEmployee]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                //sqlCommand.Parameters.AddWithValue("@FirstName", null);
                //sqlCommand.Parameters.AddWithValue("@LastName", null);
                //sqlCommand.Parameters.AddWithValue("@Designation", null);
                //sqlCommand.Parameters.AddWithValue("@Salary", null);
                //sqlCommand.Parameters.AddWithValue("@Age", null);
                //sqlCommand.Parameters.AddWithValue("@Gender", null);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public IList<EmployeeModel> DisplayEmployee()
        {
            // create a command object
            SqlCommand sqlCommand = new SqlCommand("[GetAllEmployee]", sqlConnection);
            
            //IList for storing the data into the EmployeeList
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            try
            {
                sqlConnection.Open();
                //get an instance of an sqlDataReader
                SqlDataReader dataReader   = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    employeeList.Add(new EmployeeModel
                    {
                        EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]),
                        FirstName = dataReader["FirstName"].ToString(),
                        LastName = dataReader["LastName"].ToString(),
                        Designation = dataReader["Designation"].ToString(),
                        Age = Convert.ToInt32(dataReader["Age"]),
                        Salary = Convert.ToInt32(dataReader["Salary"]),
                        Gender = dataReader["Gender"].ToString()
                    });
                }
                return employeeList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
              
                if(sqlConnection!=null)
                {
                    sqlConnection.Close();
                }
            }
        }

        public bool UpdateEmployee(EmployeeModel employeeModel, int id)
        {

            try
            {
                SqlCommand sqlCommand = new SqlCommand("[UpadateEmployee]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Designation", employeeModel.Designation);
                sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlCommand.Parameters.AddWithValue("@Age", employeeModel.Age);
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }

    
}
