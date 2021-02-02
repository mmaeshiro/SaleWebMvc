using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Relacionamento
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department( string name)
        {            
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSaleRecords(initial,final));
        }
    }
}
