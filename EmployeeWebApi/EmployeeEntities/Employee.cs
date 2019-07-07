using EmployeeEntities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntities
{
    public class Employee : IEntity
    {
        public int Index { get;set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public int JobId { get; set; }
        public string Salary { get; set; }
        public int managerId { get; set; }
        public int departmentId { get; set; }

    }
}
