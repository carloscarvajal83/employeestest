namespace EmployeeInformation.Data.Interfaces
{
    using EmployeeInformation.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(int id);
        Task<Employee> GetEmployeeById(int id);
    }
}
