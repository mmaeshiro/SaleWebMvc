using SaleWebMvc.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaleWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }

        //Relacionamento
        public Seller Seller { get; set; }

        public SalesRecord()
        {

        }

        public SalesRecord(DateTime data, double amount, SaleStatus status, Seller seller)
        {        
            Data = data;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
