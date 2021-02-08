using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;
using SaleWebMvc.Models.ViewModels;
using SaleWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        // GET: SellersController
        public ActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        // GET: SellersController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return NotFound();           

            return View(obj);
        }

        // GET: SellersController/Create
        public ActionResult Create()
        {
            var departmens = _departmentService.FindAll();
            var viewModel = new SellerViemModel { Departments = departmens };
            return View(viewModel);
        }

        // POST: SellersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seller seller)
        {
            try
            {
                _sellerService.Insert(seller);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellersController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindById(id.Value);            

            if (obj == null)
                return NotFound();

            obj.Department = _departmentService.FindAll().Where(x => x.Id == obj.DepartmentId).FirstOrDefault();

            return View(obj);
        }

        // POST: SellersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _sellerService.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
