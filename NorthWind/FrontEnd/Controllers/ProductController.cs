﻿using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        private ProductHelper productHelper;
        private CategoryHelper categoryHelper;
        private SupplierHelper supplierHelper;

        public ProductController()
        {
            productHelper = new ProductHelper();
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> products = productHelper.GetAll();

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            supplierHelper = new SupplierHelper();
            categoryHelper = new CategoryHelper();

            ProductViewModel product = new ProductViewModel();

            product.Categories = categoryHelper.GetAll();
            product.Suppliers = supplierHelper.GetAll();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productModel)
        {
            try
            {
                productHelper = new ProductHelper();
                ProductViewModel product = productHelper.Create(productModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
