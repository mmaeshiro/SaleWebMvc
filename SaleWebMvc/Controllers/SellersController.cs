using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
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

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: SellersController
        public ActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        // GET: SellersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SellersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
