using EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
   public interface IEmployeeContext
    {

        Employee Get(int id);
        IEnumerable<Employee> List { get; }
        bool Add(Employee entity);
        bool Delete(Employee entity);
        bool Update(Employee entity);
        Employee FindById(int Id);
        IEnumerable<Employee> FindByName(string name);
    }
}
