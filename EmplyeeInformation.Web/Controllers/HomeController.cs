using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EmplyeeInformation.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IConfiguration config) : base(config)
        {
        }

        public async Task<IActionResult> Index(int id)
        {
            var result = await employeeService.GetAllEmployees(id);
            return View(result);
        }
    }
}