using EmployeeInformation.Business.Interfaces;
using EmployeeInformation.Business.Services;
using EmployeeInformation.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EmplyeeInformation.Web.Controllers
{
    public class BaseController : Controller
    {
        public IConfiguration configuration { get; }

        public IEmployeeService employeeService { get; set; }

        public ServiceConfig serviceConfig { get; }

        public BaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            var appSettingsSection = configuration.GetSection("AppSettings");
            serviceConfig = appSettingsSection.Get<ServiceConfig>();
            Initialize();
        }

        public BaseController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        private void Initialize()
        {
            if (employeeService == null)
            {
                employeeService = new EmployeeService(serviceConfig);
            }
        }
    }
}