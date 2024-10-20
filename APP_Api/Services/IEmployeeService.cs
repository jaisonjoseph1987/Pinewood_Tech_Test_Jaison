
using APP_MVC.Models;

namespace APP_Api.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        List<Employee> AddEmployee(Employee employee);
        List<Employee> DeleteEmployee(int id);

        List<Employee> Update(Employee employee);
        Employee GetById(int id);
    }
}
