using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculator.Models
{
    [Table("EmployeeSalary")]
    public class EmployeeSalary
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Display(Name = "Neto Salary")]
        [Column("NetSalary")]
        [Range(6000, Double.PositiveInfinity, ErrorMessage = "The minimum net salary must be higher than 6000 RSD.")]
        [DataType(DataType.Currency)]
        public double NetSalary { get; set; }

        [Display(Name = "Gross Salary")]
        [Column("GrossSalary")]
        public double GrossSalary { get; set; }

        [Display(Name = "Taxable Base")]
        [Column("TaxableBase")]
        public double TaxableBase { get; set; }

        [Display(Name = "Tax")]
        [Column("Tax")]
        public double Tax { get; set; }

        [Display(Name = "PIO Employee")]
        [Column("PioTaxEmployee")]
        public double PioTaxEmployee { get; set; }

        [Display(Name = "Helt Tax Employee")]
        [Column("HeltTaxEmployee")]
        public double HeltTaxEmployee { get; set; }

        [Display(Name = "Unemployment Tax")]
        [Column("UnemploymentTaxEmployee")]
        public double UnemploymentTaxEmployee { get; set; }

        [Display(Name = "PIO Employer")]
        [Column("PioTaxEmployer")]
        public double PioTaxEmployer { get; set; }

        [Display(Name = "Helt Tax Employee")]
        [Column("HeltTaxEmployer")]
        public double HeltTaxEmployer { get; set; }

        [Display(Name = "Super Gross Salary")]
        [Column("SuperGrossSalary")]
        public double SuperGrossSalary { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
