using EmployeeInformation.Business.Interfaces;
using EmployeeInformation.Business.Services;
using EmployeeInformation.Core.Enums;
using EmployeeInformation.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeInformation.UnitTests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void RetrieveHourlyEmployee()
        {
            //Arrange
            var service = new Mock<IEmployeeService>();
            int employeeId = 1;
            service.Setup(x => x.GetEmployeeById(employeeId)).ReturnsAsync(MockEmployee());
            
            //Act
            IEmployeeService testService = new EmployeeService(service.Object);
            Employee result = testService.GetEmployeeById(employeeId).Result;

            //Assert
            Assert.AreEqual(result.ContractTypeName, Enums.contractType.HourlySalaryEmployee.ToString());
        }


        private HourlyEmployee MockEmployee()
        {
            var employee = new HourlyEmployee() {
                Id = 1,
                Name = "Jhon Doe",
                ContractTypeName = Enums.contractType.HourlySalaryEmployee.ToString(),
                HourlySalary = 10000
            };
            return employee;
        }
    }

}
