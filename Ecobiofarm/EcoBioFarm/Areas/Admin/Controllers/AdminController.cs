using EcoBioFarm.Service.Contracts;
using EcoBioFarm.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EcoBioFarm.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IEcoBioFarmService service;
        public AdminController(IEcoBioFarmService service)
        {
            this.service = service ?? throw new ArgumentNullException("service");
        }

        public IActionResult Index()
        {
            var model = service.GetProducts();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            //Not mandatory but we do IT
            var model = new ProductViewModel();

            return View(model);
        }

        public IActionResult CreateProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                service.CreateProduct(model);
            }
            catch (Exception ex)
            {
                // Log the Error
                throw new Exception("Something happend THROW ERROR 500");
            }

            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult EditProduct(long id)
        {
            var model = service.GetProduct(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.EditProduct(model);
                }
                catch (Exception ex)
                {
                    // Log the Error
                    throw new Exception("Something happend THROW ERROR 500");
                }
            }

            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            var model = service.GetProduct(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            service.DeleteProduct(id);

            return RedirectToAction(nameof(this.Index));
        }
    }
}