using AutoMoq;
using Moq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestEmployeeApi
{
    [TestFixture]
    class EmployeeRepositoryTest
    {
        [TestCase]
        public void Add_Employee_Context_Success()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            // lazy evaluating return value
            mockRepo.Setup(x => x.Add(employee)).Returns(true);
            bool _c1 = mockRepo.Object.Add(employee);

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
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            // lazy evaluating return value
            mockRepo.Setup(x => x.Add(null)).Returns(false);
            bool _c1 = mockRepo.Object.Add(null);

            //Assert
            Assert.AreEqual(false, _c1);
        }

        [TestCase]
        public void Get_Employee_Context_NotFound()
        {
            // Set up Prerequisites   
            int id = 1233;
            // init

            var mocker = new AutoMoqer();
            var employeeList = GetTestEmployeeList();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            mockRepo.Setup(x => x.FindById(id)).Returns(employeeList.FirstOrDefault());
            // Act  
            var _c1 = mockRepo.Object.FindById(id);

            // Assert  
            Assert.NotNull(_c1);
        }

        [TestCase]
        public void Get_Employee_Context_Found()
        {
            // Set up Prerequisites   
            int id = 100;
            var mocker = new AutoMoqer();
            // init
            var employeeList = GetTestEmployeeList();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            mockRepo.Setup(x => x.FindById(Convert.ToInt32(id))).Returns(employeeList.FirstOrDefault());
            // Act  
            var _c1 = mockRepo.Object.FindById(id);
            // Assert  
            Assert.NotNull( _c1);
        }


        [TestCase]
        public void Get_Employee_By_Id_Context_Success()
        {
            // init
            string empId = "4";
            var mocker = new AutoMoqer();
            //arrange  
            var employee = GetEmployee();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            mockRepo.Setup(x => x.FindById(4)).Returns(employee);

            //find employee
            var _c1 = mockRepo.Object.FindById(100);
            // Assert  
            Assert.IsNull(_c1);
        }

        [TestCase]
        public void Get_Employee_By_Id_Repo_Failure()
        {
            // init
            var mocker = new AutoMoqer();
            //arrange  
            var employee = GetEmployee();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            mockRepo.Setup(x => x.FindById(4)).Returns(employee);
            //find employee
            var _c1 = mockRepo.Object.FindById(-1);
            Assert.IsNull(_c1);
        }


        [TestCase]
        public void Get_Employee_List_Repo_Success()
        {
            // Set up Prerequisites   
            string firstName = "Demo";
            var mocker = new AutoMoqer();
            // init
            var employee = GetEmployee();
            var employeeList = GetTestEmployeeList();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            mockRepo.Setup(x => x.FindById(4)).Returns(employee);
            //find employee
            var _c1 = mockRepo.Object.FindById(4);
            // Assert  
            Assert.NotNull(_c1);
        }




        [TestCase]
        public void Get_Employee_List_Context_No_Record()
        {
            // Set up Prerequisites   
            string firstName = "Vishal";
            var mocker = new AutoMoqer();
            // init
            var employeeList = GetTestEmployeeList();
            //  var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            mockRepo.Setup(x => x.List).Returns(employeeList.FindAll(x => x.FirstName == firstName));
            // Act  
            var _c1 = mockRepo.Object.List.Where(x=>x.FirstName==firstName).ToList();
            // Assert  
            Assert.LessOrEqual(0, _c1.Count());
        }



        [TestCase]
        public void FailingTest()
        {
            // init
            var mocker = new AutoMoqer();
            var employee = GetEmployee();
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            // lazy evaluating return value
            mockRepo.Setup(x => x.Add(employee)).Returns(false);
            bool _c1 = mockRepo.Object.Add(employee);

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
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // var mockManger = new Mock<EmployeeCore.Interface.IEmployeeManager>();


            // lazy evaluating return value
            mockRepo.Setup(x => x.Update(employee)).Returns(true);
            bool _c1 = mockRepo.Object.Update(employee);

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
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();

            // lazy evaluating return value
            mockRepo.Setup(x => x.Update(null)).Returns(false);
            bool _c1 = mockRepo.Object.Update(null);

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
            var mockRepo = new Mock<EmployeeRepository.Interface.IEmployeeRepository>();
            // lazy evaluating return value
            mockRepo.Setup(x => x.Update(employee)).Returns(true);
            bool _c1 = mockRepo.Object.Update(employee);
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
