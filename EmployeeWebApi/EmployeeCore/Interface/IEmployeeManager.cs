using EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeCore.Interface
{
   public interface IEmployeeManager
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee entity);
        bool DeleteEmployee(Employee entity);
        bool UpdateEmployee(Employee entity);
    }
}
