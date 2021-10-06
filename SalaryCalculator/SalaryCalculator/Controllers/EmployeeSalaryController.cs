using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SalaryCalculator.ViewModel;

namespace SalaryCalculator.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeSalaryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public EmployeeSalary Salary { get; set; }

        /*
         * This method will list all existing Employee.
        */
        public IActionResult Index()
        {
             var viewEmployes = (from e in _db.Employees
                       join s in _db.Salaries on e.Id equals s.Id
                       select new EmployeeVM
                       {
                           Id = e.Id,
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           NetSalary = s.NetSalary,
                           Tax = s.Tax,
                           PioTaxEmployee = s.PioTaxEmployee,
                           HeltTaxEmployee = s.HeltTaxEmployee,
                           UnemploymentTaxEmployee = s.UnemploymentTaxEmployee,
                           GrossSalary = s.GrossSalary,
                           PioTaxEmployer = s.PioTaxEmployer,
                           HeltTaxEmployer = s.HeltTaxEmployer,
                           SuperGrossSalary = s.SuperGrossSalary
                       }).ToList();

            return View(viewEmployes);
            
        }
        /*
        * This method will provide the medium to add a new Employee.
        */
        public IActionResult Upsert(int? id)
        {
            Employee = new Employee();
            Employee.Salary = new EmployeeSalary();
            if (id == null)
            {
                //create
                return View(Employee);
            }

            //update
            Employee = _db.Employees.FirstOrDefault(u => u.Id == id);
            Employee.Salary = _db.Salaries.FirstOrDefault(u => u.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Employee.Id == 0)
                {
                    // create
                    _db.Employees.Add(Employee);
                }
                else
                {
                    _db.Employees.Update(Employee);
                    _db.Salaries.Update(Employee.Salary);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        /*
         * This method will be called on form submission, handling POST request for
        * saving Employee in database. It also validates the Employee input
        */
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Employees.Remove(employeeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }

        /*
         * This method will list all existing Employee.
         * An return JSON which we dynamically load into the table with the help AJAX
        */
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var a = await (from e in _db.Employees
                     join s in _db.Salaries on e.Id equals s.Id
                     select new EmployeeVM
                     {
                         Id = e.Id,
                         FirstName = e.FirstName,
                         LastName = e.LastName,
                         NetSalary = s.NetSalary,
                         Tax = s.Tax,
                         PioTaxEmployee = s.PioTaxEmployee,
                         HeltTaxEmployee = s.HeltTaxEmployee,
                         UnemploymentTaxEmployee = s.UnemploymentTaxEmployee,
                         GrossSalary = s.GrossSalary,
                         PioTaxEmployer = s.PioTaxEmployer,
                         HeltTaxEmployer = s.HeltTaxEmployer,
                         SuperGrossSalary = s.SuperGrossSalary
                     }).ToListAsync();

            return Json(new { data = a });
        }

      
    }
}
