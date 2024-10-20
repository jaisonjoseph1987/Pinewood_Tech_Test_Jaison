using APP_Api.Services;
using APP_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public List<Employee> CreateEmployee(Employee employee)
        {
            var response = _employeeService.AddEmployee(employee);
            return response;

           
        }

       
        [HttpPost]
        public List<Employee> UpdateEmployee(Employee employee)
        {
            var existingEmployee = _employeeService.GetById(employee.Id);
            var response = _employeeService.Update(employee);
            return response;
        }


        [HttpDelete("{id}")]
        public List<Employee> DeleteEmployee(int id)
        {
          

            var response = _employeeService.DeleteEmployee(id);
            return response;
        }

    }
}
