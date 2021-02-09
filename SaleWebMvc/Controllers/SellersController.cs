using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;
using SaleWebMvc.Models.ViewModels;
using SaleWebMvc.Services;
using SaleWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        // GET: SellersController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        // GET: SellersController/Create
        public async Task<IActionResult> Create()
        {
            var departmens = await _departmentService.FindAllAsync();
            var viewModel = new SellerViemModel { Departments = departmens };
            return View(viewModel);
        }

        // POST: SellersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var department = await _departmentService.FindAllAsync();
                    var viewModel = new SellerViemModel { Seller = seller, Departments = department };
                    return View(viewModel);
                };

                await _sellerService.InsertAsync(seller);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = await _departmentService.FindAllAsync();

            SellerViemModel sellerViemModel = new SellerViemModel { Seller = obj, Departments = departments };

            return View(sellerViemModel);
        }

        // POST: SellersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid) 
            {
                var department = await _departmentService.FindAllAsync();
                var viewModel = new SellerViemModel { Seller = seller, Departments = department };
                return View(viewModel);
            };          

            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            try
            {

                await _sellerService.UpdateAsync(seller);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: SellersController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });           

            return View(obj);
        }

        // POST: SellersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _sellerService.RemoveAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
