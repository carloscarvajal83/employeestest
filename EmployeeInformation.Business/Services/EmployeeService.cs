namespace EmployeeInformation.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeInformation.Business.Interfaces;
    using EmployeeInformation.Core.Enums;
    using EmployeeInformation.Core.Models;
    using EmployeeInformation.Data.Interfaces;
    using EmployeeInformation.Data.Repository;

    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository Service { get; set; }

        public EmployeeService(IEmployeeService service)
        {
            this.Service = service;
        }

        public EmployeeService(ServiceConfig config)
        {
            Service = new EmployeeRepository(config);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(int id)
        {
            List<Employee> result = new List<Employee>();
            var employeeList = await Service.GetAllEmployees(id);
            foreach(var item in employeeList)
            {
                var employee = ResolveEmployeeType(item);
                if (employee != null){
                    result.Add(employee);
                }
            }
            return result;
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var result = await Service.GetEmployeeById(Id);
            var employee = ResolveEmployeeType(result);
            return employee;
        }

        private Employee ResolveEmployeeType(Employee employee)
        {
            Employee result = null;
            if (employee.ContractTypeName == null)
            {
                return result;
            }
            if (employee.ContractTypeName.Equals(Enums.contractType.HourlySalaryEmployee.ToString()))
            {
                HourlyEmployee hourly = employee.As<HourlyEmployee>();
                return hourly;
            }
            else if (employee.ContractTypeName.Equals(Enums.contractType.MonthlySalaryEmployee.ToString()))
            {
                MonthlyEmployee monthly = employee.As<MonthlyEmployee>();
                return monthly;
            }
            return result;
        }
    }
}
