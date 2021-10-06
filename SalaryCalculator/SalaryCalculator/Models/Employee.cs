using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculator.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Column("LastName")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Adress")]
        [Column("Adress")]
        [Required]
        public string Adress { get; set; }

        public virtual EmployeeSalary Salary { get; set; }
    }
}
