using KE.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace KalpitaEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
       public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService)); ;
        }

        [Route("Developers")]
        [HttpGet]

        public async Task<IActionResult> GetDevelopers()
        {
            var employee = await _employeeService.GetDevelopers();
            return Ok(employee);
  
        }
        
    }
}
