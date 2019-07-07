using AutoMoq;
using Moq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EmployeeWebApi.Extension;
using EmployeeEntities;
using System.Web.Http.Results;

namespace UnitTestEmployeeApi
{
    class EmployeeControllerTest
    {
        [TestCase]
        public void Get_Employee_Controller_Success()
        {
            // init
            var mocker = new AutoMoqer();
            var employeeList = GetTestEmployeeList();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
           
            // Arrange

            mockManger.Setup(m => m.GetEmployeeList()).Returns(employeeList);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = controller.Get(1, 10);

             
                       // Assert

            Assert.IsNotNull(response);
            Assert.Pass("Returned content",response);

        }

        [TestCase]
        public void Add_Employee_Controller_Failure()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetTestEmployeeList();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.AddEmployee(null)).Returns(false);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = controller.Post(null);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }

        [TestCase]
        public void Get_Employee_Controller_NotFound()
        {
            // Set up Prerequisites   
            string firstName = "Demo1233";
            // init
            // init
            var mocker = new AutoMoqer();
            var employee = GetTestEmployeeList();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.AddEmployee(null)).Returns(false);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = controller.Get(1000);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }

        [TestCase]
        public void Add_Employee_Controller_Sucess()
        {

            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.AddEmployee(employee)).Returns(true);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var _mod = new EmployeeWebApi.Models.EmployeeModel {

                FirstName= employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };
            

            // Act
            var response = controller.Post(_mod);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }


        [TestCase]
        public void Get_Employee_By_Id_Context_Success()
        {

            // Set up Prerequisites   

            // init
            var mocker = new AutoMoqer();
            var employeeList = GetTestEmployeeList();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.GetEmployeeList()).Returns(employeeList);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = controller.Get(100);
            // Assert
            
            Assert.NotNull(response);
        }

        [TestCase]
        public void Get_Employee_By_Id_Context_Failure()
        {
            // Set up Prerequisites   

            // init
            var mocker = new AutoMoqer();
            var employeeList = GetTestEmployeeList();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.GetEmployeeList()).Returns(employeeList);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = controller.Get(10000);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }


        [TestCase]
        public void Update_Employee_List_Context_Success()
        {

            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.UpdateEmployee(employee)).Returns(true);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var _mod = new EmployeeWebApi.Models.EmployeeModel
            {

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };


            // Act
            var response = controller.Put(_mod);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }

        [TestCase]
        public void Update_Employee_Model_Null_BadRequest()
        {

            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.UpdateEmployee(employee)).Returns(true);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var _mod = new EmployeeWebApi.Models.EmployeeModel
            {

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };


            // Act
            var response = controller.Put(null);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }


        [TestCase]
        public void Delete_Employee_Controller_Success()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.UpdateEmployee(employee)).Returns(true);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var _mod = new EmployeeWebApi.Models.EmployeeModel
            {

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };


            // Act
            var response = controller.Delete(4);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }



        [TestCase]
        public void FailingTest()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockContext = new Mock<EmployeeRepository.Interface.IEmployeeContext>();

            // lazy evaluating return value
            mockContext.Setup(x => x.Add(employee)).Returns(false);
            bool _c1 = mockContext.Object.Add(employee);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(false, _c1);
        }


        [TestCase]
        public void Delete_Context_Employee_Failure()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // Arrange

            mockManger.Setup(m => m.UpdateEmployee(employee)).Returns(true);
            var controller = new EmployeeWebApi.Controllers.EmployeeController(mockManger.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var _mod = new EmployeeWebApi.Models.EmployeeModel
            {

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary
            };


            // Act
            var response = controller.Delete(4);

            // Assert
            Assert.IsNotNull(response);
            Assert.NotNull(response);
        }


        private List<EmployeeEntities.Employee> GetTestEmployeeList()
        {
            var testEmployee = new List<EmployeeEntities.Employee>();
            testEmployee.Add(new EmployeeEntities.Employee { EmployeeId = "1", FirstName = "Demo1", LastName = "Last Demo1", Email = "demo1@test.com" });
            testEmployee.Add(new EmployeeEntities.Employee { EmployeeId = "2", FirstName = "Demo2", LastName = "Last Demo2", Email = "demo2@test.com" });
            testEmployee.Add(new EmployeeEntities.Employee { EmployeeId = "3", FirstName = "Demo3", LastName = "Last Demo3", Email = "demo3@test.com" });
            testEmployee.Add(new EmployeeEntities.Employee { EmployeeId = "4", FirstName = "Demo4", LastName = "Last Demo4", Email = "demo4@test.com" });

            return testEmployee;
        }


        private EmployeeEntities.Employee GetEmployee()
        {
            return new EmployeeEntities.Employee { EmployeeId = "1",FirstName = "Demo4", LastName = "Last Demo4", Email = "demo4@test.com", PhoneNumber = "909090", HireDate = DateTimeOffset.UtcNow, JobId = 1, departmentId = 1, managerId = 1 };

        }
    }
}
