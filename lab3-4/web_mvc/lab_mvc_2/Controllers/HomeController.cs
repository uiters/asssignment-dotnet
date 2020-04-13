using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lab_mvc_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab_mvc_2.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController (ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index () {
            return RedirectToAction ("Create");
        }

        public IActionResult Privacy () {
            return View ();
        }

        [HttpGet]
        public ViewResult ViewAllProducts () {
            var model = ProductData.ProductList;
            return View ("ViewAllProducts", model);
        }

        [HttpGet]
        public ViewResult Create () {
            TempData["CreateOrEdit"] = "Create";
            return View ();
        }

        [HttpPost]
        public ViewResult Create (Product newProduct) {
            TempData["CreateOrEdit"] = "Create";
            if (ProductData.AddProduct (newProduct)) {
                ViewBag.Message = "Product(" + ProductData.ProductList.Count + ") added successful";
            } else {
                ViewBag.Message = "Can not add this product";
            }
            return View ();
        }

        [HttpGet]
        public ViewResult Edit (int ProID) {
            TempData["CreateOrEdit"] = "Edit";
            var product = ProductData.GetProductByID (ProID);
            return View (product);
        }

        [HttpPost]
        public ViewResult Edit (Product editProduct) {
            TempData["CreateOrEdit"] = "Edit";
            if (ProductData.UpdateProduct (editProduct)) {
                ViewBag.Message = "Product updated successful";
            } else {
                ViewBag.Message = "Can not update product";
            }
            return View ();
        }

        public ActionResult Delete (int ProID) {
            if (ProductData.DeleteProduct (ProID)) {
                ViewBag.Message = "Product deleted successful";
            } else {
                ViewBag.Message = "Can not delete this product";
            }

            return RedirectToAction("Index");
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}