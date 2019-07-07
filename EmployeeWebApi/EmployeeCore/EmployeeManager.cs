using EmployeeCore.Interface;
using EmployeeEntities;
using EmployeeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCore
{
    public class EmployeeManger : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeManger(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public Employee GetEmployee(int id)
        {
            var result = _employeeRepo.FindById(id);
            return result;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            var result = _employeeRepo.List;
            return result;
        }

        public bool AddEmployee(Employee enity)
        {
            return _employeeRepo.Add(enity);
        }

        public bool UpdateEmployee(Employee enity)
        {
            return _employeeRepo.Update(enity);
        }

        public bool DeleteEmployee(Employee enity)
        {
            return _employeeRepo.Delete(enity);
        }
    }
}
