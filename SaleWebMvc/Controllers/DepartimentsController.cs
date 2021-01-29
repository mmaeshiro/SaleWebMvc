using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Controllers
{
    public class DepartimentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> listDepartment = new List<Department>();
            listDepartment.Add(new Department { Id = 1, Name = "Eletronicos" });
            listDepartment.Add(new Department { Id = 2, Name = "Fashion" });

            return View(listDepartment);
        }
    }
}
