using APP_MVC.Models;

namespace APP_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Jaison",Surname="Joseph", Nationality = "UK",Salary = 25000 },
                new Employee { Id = 2, Name = "Neo",Surname="Jaison", Nationality = "USA",Salary=45000 },
                new Employee { Id = 3, Name = "Neethu",Surname="Joseph", Nationality = "Australia",Salary=55000 }
            };
            
        }
        public List<Employee> AddEmployee(Employee employee)
        {
            employee.Id = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
            

            return _employees;
        }

        public List<Employee> DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return _employees;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> Update(Employee employee)
        {
            foreach (var emp in _employees)
            {
                if (emp.Id == employee.Id)
                {
                    emp.Name = employee.Name;
                    emp.Surname = employee.Surname;
                    emp.Salary = employee.Salary;
                    emp.Nationality = employee.Nationality;
                }
            }

            return _employees;
        }
    }
}
