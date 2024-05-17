using AdoRelation.DAL;
using AdoRelation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoRelation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentDAL departmentDAL;
        public DepartmentController() 
        {
            departmentDAL = new DepartmentDAL();
        }
        public IActionResult Index()
        {
            List<Department> depList=departmentDAL.GetAlDepartments();
            return View(depList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            try
            {
                departmentDAL.CreateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
          
        }
    }
}
