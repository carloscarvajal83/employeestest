namespace EmployeeInformation.Data.Repository
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using EmployeeInformation.Core.Models;
    using EmployeeInformation.Data.Interfaces;

    public class EmployeeRepository : IEmployeeRepository
    {
        private string urlApi { get; set; }

        private HttpClient httpClient { get; set; }

        public EmployeeRepository(ServiceConfig config)
        {
            this.urlApi = config.ApiUrl;
            this.Initialize();
        }

        private void Initialize()
        {
            if (httpClient == null) {
                this.httpClient = new HttpClient();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(int id)
        {
            var employeeList = await GetEmployeesList();
            if (id > 0)
            {
                employeeList = employeeList.Where(x => x.Id == id);
            }
            return employeeList;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employeeList = await GetEmployeesList();
            var employee = employeeList.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        private async Task<IEnumerable<Employee>> GetEmployeesList()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                var response = await this.httpClient.GetAsync(urlApi);
                string apiResponse = await response.Content.ReadAsStringAsync();
                employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
            }
            catch (Exception ex)
            {
            }
            return employeeList;
        }
    }
}
