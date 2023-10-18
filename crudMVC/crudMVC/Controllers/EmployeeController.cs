using crudMVC.Data;
using crudMVC.Models;
using crudMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace crudMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public Mvc_demo_DbContext mvcDbContext;

        public EmployeeController(Mvc_demo_DbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                salary = addEmployeeViewModel.salary,
                Department = addEmployeeViewModel.Department,
                DateOfBirth = addEmployeeViewModel.DateOfBirth,

            };
            return View(addEmployeeViewModel);
        }
    }
}
