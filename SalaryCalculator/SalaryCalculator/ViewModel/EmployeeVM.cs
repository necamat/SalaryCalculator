using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculator.ViewModel
{
    public class EmployeeVM
    {

        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Neto Salary")]
        public double NetSalary { get; set; }
        [Display(Name = "Tax")]
        public double Tax { get; set; }
        [Display(Name = "PIO Employee")]
        public double PioTaxEmployee { get; set; }
        [Display(Name = "Helt Tax Employee")]
        public double HeltTaxEmployee { get; set; }
        [Display(Name = "Unemployment Tax")]
        public double UnemploymentTaxEmployee { get; set; }
        [Display(Name = "Gross Salary")]
        public double GrossSalary { get; set; }
        [Display(Name = "PIO Employer")]
        public double PioTaxEmployer { get; set; }
        [Display(Name = "Helt Tax Employee")]
        public double HeltTaxEmployer { get; set; }
        [Display(Name = "Super Gross Salary")]
        public double SuperGrossSalary { get; set; }


    }
}
