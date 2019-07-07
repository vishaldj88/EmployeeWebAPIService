using EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
  public  interface IEmployeeRepository : IRepository<Employee>
    {
    }


    //public class _Employee
    //{
    //    string Id { get; set; }
    //}
}
