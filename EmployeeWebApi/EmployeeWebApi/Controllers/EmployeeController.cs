using EmployeeCore.Interface;
using EmployeeEntities;
using EmployeeWebApi.Extension;
using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EmployeeWebApi.Controllers
{

   
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeManager _employeeManager;
        /// <summary>
        /// Injects IEmployeeManager from Employee Core library
        /// </summary>
        /// <param name="employeeManager"></param>
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        // GET: api/Employees  

        ////////////////////////////////////////////////////////////////////////////////////////////////////  
        /// <summary>   Gets the employees. </summary>  
        ///  
        /// <remarks> List of all employees </remarks>  
        ///  
        /// <returns>   The employees. </returns>  
        ///////////////
        [HttpGet]
        [Route("api/employee")]
        [ResponseType(typeof(ServiceResponse<IEnumerable<Employee>>))]
        public IHttpActionResult Get(int page,int pageSize)
        {
            //
            var empList = new ServiceResponse<IEnumerable<Employee>>();
            empList.Data = null;
            if (page < 1 || pageSize< 1)
            {
                return BadRequest("invalid page or pageSize ");
            }

            var _employeeList = PageExtension.Page(_employeeManager.GetEmployeeList(), page, pageSize);

            
            empList.Data =_employeeList;
            empList.statusCode = HttpStatusCode.OK;

            return Ok(empList);
        }

        // GET api/values/5
        [HttpGet]
        [Route("employee/{Id}")]
        [ResponseType(typeof(ServiceResponse<Employee>))]
        public IHttpActionResult Get(int id)
        {
            var emp = new ServiceResponse<Employee>();
            emp.Data = null;
            try
            {
                if (id < 100)
                {
                    return NotFound();
                }
                if (id < 1)
                {
                    return BadRequest("invalid message Id");
                }
                var _employee = _employeeManager.GetEmployee(id);
                if (_employee.EmployeeId == null)
                {
                    return NotFound();
                }
                emp.Data = _employee;
                emp.statusCode = HttpStatusCode.OK;
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("employee")]
        [ResponseType(typeof(ServiceResponse<bool>))]
        public IHttpActionResult Post(EmployeeModel employee)
        {
            var emp = new ServiceResponse<bool>();
            emp.Data = false;

            try
            {
                if (employee ==null)
                {
                    return BadRequest("Invalid data , Unable to add employee.");
                }

                if (employee != null)
                {
                    _employeeManager.AddEmployee(
                        new Employee
                        {
                            EmployeeId = employee.EmployeeId,
                            Email = employee.Email,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            PhoneNumber = employee.PhoneNumber,
                            Salary = employee.Salary,
                            HireDate = employee.HireDate
                        }
                    );
                    emp.Data = true;

                    string content = "Employee created successful";
                    //var response = new HttpResponseMessage
                    //{
                    //    Content = new StringContent(content)
                    //};
                    //response.Content.Headers.Add(@"Content-Length", content.Length.ToString());

                    return Content(HttpStatusCode.NoContent, "Employee created successful");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return InternalServerError();
        }

        // PUT api/values/5
        [HttpPut]
        [Route("employee")]
        //[ResponseType(typeof(ServiceResponse<bool>))]
        public IHttpActionResult Put(EmployeeModel employee)
        {
            var emp = new ServiceResponse<bool>();
            emp.Data = false;
            try
            {
                if (Convert.ToInt32(employee.EmployeeId) < 100)
                {
                    return NotFound();
                }
                if (employee == null)
                {
                    return BadRequest("Invalid data , Unable to add employee.");
                }

                if (employee != null)
                {
                    _employeeManager.UpdateEmployee(
                    new Employee
                    {
                        EmployeeId = employee.EmployeeId,
                        Email = employee.Email,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        PhoneNumber = employee.PhoneNumber,
                        Salary = employee.Salary,
                        HireDate = employee.HireDate
                    }
                    );
                    emp.Data = true;
                    return Content(HttpStatusCode.NoContent, "Employee Updated successful");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest("please check the request ");

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("employee/{Id}")]
        [ResponseType(typeof(ServiceResponse<bool>))]
        public IHttpActionResult Delete(int id)
        {
            var emp = new ServiceResponse<bool>();
            emp.Data = false;
            try
            {
                if (id < 100)
                {
                    return BadRequest("Invalid data , Unable to delete employee.");
                }
                
                if (id>0)
                {
                    _employeeManager.DeleteEmployee(new Employee { EmployeeId = id.ToString() });
                    emp.Data = true;
                    //return Ok(emp);
                    return Content(HttpStatusCode.NoContent, "Delete successful");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest("please check the request ");
        }
    }
}
