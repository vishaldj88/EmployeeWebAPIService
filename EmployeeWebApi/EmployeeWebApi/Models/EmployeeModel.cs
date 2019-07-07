using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.Models
{
    public class EmployeeModel
    {
        [DisplayName("Id")]
        public string EmployeeId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email ID")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Hire Date")]
        public DateTimeOffset HireDate { get; set; }
        [DisplayName("Salary")]
        public string Salary { get; set; }
    }
}