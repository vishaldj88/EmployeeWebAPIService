using Dapper;
using EmployeeEntities;
using EmployeeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeRepository
{
    public class EmployeeContext : IEmployeeContext
    {


        private static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
        }
        
        public Employee FindById(int Id)
        {        
            return Get(Id);
        }

        public Employee Get(int id)
        {

            string sql = "select employee_id as EmployeeId,first_name as FirstName,last_name as LastName,email as Email,phone_number as PhoneNumber,hire_date as HireDate,job_id as JobId,salary as Salary,manager_id as managerId,department_id as departmentId from [dbo].[employees] where employee_id=@ID";
            using (var connection = new SqlConnection(ConnectionString()))
            {
                var employee = connection.Query<Employee>(sql,param : new{ID=id}).ToList().FirstOrDefault();

                return employee;
            }
        }

        public IEnumerable<Employee> List
        {
            get
            {
                var _con = new List<Employee>();
                string sql = "select  ROW_NUMBER() OVER (ORDER BY employee_id) AS [Index],employee_id as EmployeeId,first_name as FirstName,last_name as LastName,email as Email,phone_number as PhoneNumber,hire_date as HireDate,job_id as JobId,salary as Salary,manager_id as managerId,department_id as departmentId from [dbo].[employees]";

                using (var connection = new SqlConnection(ConnectionString()))
                {
                    var employeeList = connection.Query<Employee>(sql).ToList().AsEnumerable();

                    return employeeList;
                }
            }
        }

        public bool Add(Employee entity)
        {
            bool success = false;
            try
            {
                entity.JobId = 1;
                entity.managerId = 100;
                entity.departmentId = 8;

                string insertQuery = @"INSERT INTO [dbo].[employees] ([first_name],[last_name],[email],[phone_number],[hire_date],[job_id],[salary],[manager_id],[department_id]) VALUES (@firstname,@lastname,@email,@phoneNumber,@HireDate,@jobId,@salary,null,@departmentId)";
                using (var connection = new SqlConnection(ConnectionString()))
                {
                    int employee = connection.Execute(insertQuery, 
                        param: new
                        {
                            entity.FirstName,
                            entity.LastName,
                            entity.Email,
                            entity.PhoneNumber,
                            entity.HireDate,
                            entity.JobId,
                            entity.Salary,
                            entity.managerId,
                            entity.departmentId
                        });

                    if (employee > 0) return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return success;
        }

        public bool Delete(Employee entity)
        {
            bool success = false;
            string deleteQuery = @"DELETE FROM [dbo].[employees] where [employee_id]=@ID";
            using (var connection = new SqlConnection(ConnectionString()))
            {
                int employee = connection.Execute(deleteQuery,
                    param: new
                    {
                        ID =entity.EmployeeId
                    });
                if (employee > 0) return true;
            }

            return success;
        }

        public bool Update(Employee entity)
        {
            bool success = false;

            entity.JobId = 1;
            entity.managerId = 100;
            entity.departmentId = 8;
            string updateQuery = @"UPDATE [dbo].[employees] SET [first_name]=@FirstName,[last_name]=@LastName,[email]=@EmailId,[phone_number]=@PhoneNumber,[hire_date]=@HireDate,[salary]=@Salary where [employee_id]=@ID";
            using (var connection = new SqlConnection(ConnectionString()))
            {
                int employee = connection.Execute(updateQuery,
                    param: new
                    {
                        ID = entity.EmployeeId,
                        entity.FirstName,
                        entity.LastName,
                        EmailId = entity.Email,
                        entity.PhoneNumber,
                        entity.HireDate,
                        entity.Salary
                    });
                if (employee > 0) return true;
            }
            return success;
        }

        

        public IEnumerable<Employee> FindByName(string name)
        {
            var _c = List;

            return _c.Where(x => x.FirstName == name);
            
        }
    }
}
