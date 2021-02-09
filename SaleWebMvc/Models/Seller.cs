using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SaleWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        //Relacionamento
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        //Relacionamento
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSaleRecords(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSaleRecords(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSaleRecords(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(x => x.Data >= initial && x.Data <= final)
                               .Sum(x => x.Amount);
        }
    }
}
