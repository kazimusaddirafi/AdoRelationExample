using AdoRelation.DAL;
using AdoRelation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdoRelation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL employeeDAL;
        private readonly DepartmentDAL departmentDAL;
        public EmployeeController()
        {
            employeeDAL = new EmployeeDAL();
            departmentDAL = new DepartmentDAL();
        }
        public IActionResult Index()
        {
            List<Employee> employees = employeeDAL.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = departmentDAL.GetAlDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                employeeDAL.CreateNewEmployee(emp);
                return RedirectToAction("index");

            }
            catch (Exception ex) { return View(); }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Edit(Employee emp)
        {
            try
            {
                employeeDAL.UpdateEmployee(emp);
                return RedirectToAction("index");

            }
            catch (Exception ex) { return BadRequest(new { msg = "Something went wrong" }); }

        }
        public IActionResult Details(int id)
        {
            Employee employee = employeeDAL.GetEmployeeDetails(id);
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = employeeDAL.GetEmployeeDetails(id);
            var departments = departmentDAL.GetAlDepartments();
            // Create a SelectList with the selected department
            ViewBag.Departments = new SelectList(departments, "Id", "DepartmentName", employee.DepartmentId);
            
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = employeeDAL.GetEmployeeDetails(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Employee employee)
        {
            try
            {
                employeeDAL.DeleteEmploye(employee.Id);
                return RedirectToAction("index");

            }
            catch (Exception ex) { return View(); }

        }


    }
}
