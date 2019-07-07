using AutoMoq;
using Moq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestEmployeeApi
{
    [TestFixture]
    class EmployeeManagerTest
    {
        [TestCase]
        public void Add_Employee_Context_Success()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
           
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.AddEmployee(employee)).Returns(true);
            bool _c1 = mockManger.Object.AddEmployee(employee);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(true, _c1);
        }

        [TestCase]
        public void Add_Employee_Context_Failure()
        {
            // init
            var mocker = new AutoMoqer();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.AddEmployee(null)).Returns(false);
            bool _c1 = mockManger.Object.AddEmployee(null);

            //Assert
            Assert.AreEqual(false, _c1);
        }

        [TestCase]
        public void Get_Employee_Context_NotFound()
        {
            // Set up Prerequisites   
            string firstName = "Demo1233";
            // init

            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            mockManger.Setup(x => x.GetEmployee(4)).Returns(employee);
            // Act  
            var _c1 = mockManger.Object.GetEmployee(4);

            // Assert  
            Assert.IsNotNull(_c1);
        }

        [TestCase]
        public void Get_Employee_Context_Found()
        {
            // Set up Prerequisites   
            string firstName = "Demo1";
            var mocker = new AutoMoqer();
            // init
            var employee = GetEmployee();
            
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            mockManger.Setup(x => x.GetEmployee(4)).Returns(employee);
            // Act  
            var _c1 = mockManger.Object.GetEmployee(4);
            // Assert  
            Assert.NotNull(_c1);
        }


        [TestCase]
        public void Get_Employee_By_Id_Context_Success()
        {
            // init
            var mocker = new AutoMoqer();
            // init
            var employee = GetEmployee();

            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            mockManger.Setup(x => x.GetEmployee(4)).Returns(employee);
            // Act  
            var _c1 = mockManger.Object.GetEmployee(4);
            // Assert  
            Assert.NotNull(_c1);
        }

        [TestCase]
        public void Get_Employee_By_Id_Context_Failure()
        {
            var mocker = new AutoMoqer();
            // init
            var employee = GetEmployee();

            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            mockManger.Setup(x => x.GetEmployee(4)).Returns(employee);
            // Act  
            var _c1 = mockManger.Object.GetEmployee(4);
            // Assert  
            Assert.NotNull(_c1);
        }


        [TestCase]
        public void Get_Employee_List_Context_Success()
        {
            // Set up Prerequisites   
            string firstName = "Demo";
            var mocker = new AutoMoqer();
            // init
            var employeeList = GetTestEmployeeList();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            mockManger.Setup(x => x.GetEmployeeList()).Returns(employeeList);
            // Act  
            var _c1 = mockManger.Object.GetEmployeeList().ToList();
            // Assert  
            Assert.GreaterOrEqual(4, _c1.Count());
        }




        [TestCase]
        public void Get_Employee_List_Context_No_Record()
        {
            // Set up Prerequisites   
            string firstName = "Demo";
            var mocker = new AutoMoqer();
            // init
            var employeeList = GetTestEmployeeList();
            
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            mockManger.Setup(x => x.GetEmployeeList()).Returns(employeeList);
            // Act  
            var _c1 = mockManger.Object.GetEmployeeList().ToList().Select(f=>f.FirstName==firstName).ToList();
            // Assert  
            Assert.GreaterOrEqual(4, _c1.Count());
        }



        [TestCase]
        public void FailingTest()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.AddEmployee(employee)).Returns(false);
            bool _c1 = mockManger.Object.AddEmployee(employee);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(false, _c1);
        }


        [TestCase]
        public void Udpdate_Context_Employee_Sucess()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.UpdateEmployee(employee)).Returns(true);
            bool _c1 = mockManger.Object.UpdateEmployee(employee);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(true, _c1);
        }


        [TestCase]
        public void Udpdate_Context_Employee_Failure()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.UpdateEmployee(null)).Returns(false);
            bool _c1 = mockManger.Object.UpdateEmployee(null);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(false, _c1);
        }


        [TestCase]
        public void DefaultGetEmployerList()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();

            // lazy evaluating return value
            mockManger.Setup(x => x.UpdateEmployee(employee)).Returns(true);
            bool _c1 = mockManger.Object.UpdateEmployee(employee);

            //Assert
            Assert.IsNotNull(_c1);
            Assert.AreEqual(true, _c1);

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
            return new EmployeeEntities.Employee { FirstName = "Demo4", LastName = "Last Demo4", Email = "demo4@test.com", PhoneNumber = "909090", HireDate = DateTimeOffset.UtcNow, JobId = 1, departmentId = 1, managerId = 1 };

        }
    }
}
