using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWebAPI_Cliente.Models;

namespace CRUDWebAPI_Cliente.Controllers
{
    public class ProductController : Controller
    {
        // GET: Customer  
        public ActionResult Index()
        {
            ProductClient CC = new ProductClient();
            ViewBag.listProducts = CC.FindAll();

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ProductClient cvm)
        {
            ProductClient CC = new ProductClient();
            CC.Create(cvm.Product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductClient CC = new ProductClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductClient CC = new ProductClient();
            ProductClient CVM = new ProductClient()
            {
                Product = CC.Find(id)
            };
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(ProductClient CVM)
        {
            ProductClient CC = new ProductClient();
            CC.Edit(CVM.Product);
            return RedirectToAction("Index");
        }


    }
}