using EmployeeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeEntities;


namespace EmployeeRepository
{

    public class EmployeeRepository : IEmployeeRepository
    {

        // Model1 _authorContext;

        private readonly IEmployeeContext _employeeContext;
        /// <summary>
        /// Injects IEmployeeContext from Employee Context library
        /// </summary>
        /// <param name="employeeManager"></param>
        public EmployeeRepository(IEmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

       
        public Employee Get(int id)
        {
            return _employeeContext.Get(id);
        }

        public IEnumerable<Employee> List
        {
            get
            {
                var _con = _employeeContext.List;
                
                return _con;
            }

        }

        public bool Add(Employee entity)
        {
           return _employeeContext.Add(entity);
        }

        public bool Delete(Employee entity)
        {
            return _employeeContext.Delete(entity);
        }

        public bool Update(Employee entity)
        {
            return _employeeContext.Update(entity);
        }

        public Employee FindById(int Id)
        {
            //var result = (from r in _authorContext.Authors where r.Id == Id select r).FirstOrDefault();
            //return result;

            return Get(Id);
        }
    }
  }
