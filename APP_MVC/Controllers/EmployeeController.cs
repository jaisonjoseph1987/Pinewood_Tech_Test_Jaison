using APP_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace APP_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>();

        public async Task<IActionResult> Index()
        {


            if (employees.Count == 0)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:7033/api/Employee/GetAllEmployees"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //Add newtonsoft.json nuget package
                        employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                    }
                }
            }

            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            Employee employee  = new Employee();
            return View(employee);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Employee employee)
        {
            // Convert the employee object to JSON
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("https://localhost:7033/api/Employee/CreateEmployee", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();



                    //Add newtonsoft.json nuget package for JsonConvert
                    employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);

                    
                }
            }

            return RedirectToAction("Index", employees);
        }



       
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            // Convert the employee object to JSON
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("https://localhost:7033/api/Employee/UpdateEmployee", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();



                    //Add newtonsoft.json nuget package for JsonConvert
                    employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);

                    
                }
            }

            return RedirectToAction("Index", employees);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var employee = employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee);
        }



        public IActionResult Delete(int id)
        {
            //employees = _employeeService.DeleteEmployee(id);

            // No access to Api/ Service layer due to data reloads
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return RedirectToAction("Index", employees);
        }
    }
}
