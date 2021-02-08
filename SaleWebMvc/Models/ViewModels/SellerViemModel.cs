using System.Collections.Generic;

namespace SaleWebMvc.Models.ViewModels
{
    public class SellerViemModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
