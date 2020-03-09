using Ornek.Dal.Concrete.EF.Repo;
using Ornek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ornek.Bll;
using Ornek.Entities.Models;
using Ornek.Pre.Models;
using System.Web.Script.Serialization;

namespace Ornek.Pre.Controllers
{
    public class HomeController : Controller
    {
        IGenericService1<Products> genericService = new GenericManager<Products>(new GenericRepo<Products>());
        
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult List()
        {

         
            var all = genericService.GetAll().ToList();
            return View(all);
        }
        
        public ActionResult Add_P( )
        {
            var categories = new List<Categories>();
            categories.Add(new Categories() { CategoryID = 1, CategoryName = "electronics" });
            categories.Add(new Categories() { CategoryID = 2, CategoryName = "computers" });
            categories.Add(new Categories() { CategoryID = 3, CategoryName = "home" });
            categories.Add(new Categories() { CategoryID = 4, CategoryName = "kitchens" });


            categories.ToList();
            ViewBag.Categories=(categories);

            return View();
        }

        public ActionResult Display_P()
        {
            var all = genericService.GetAll().ToList();
            return View(all);
        }

        [HttpPost]
        public JsonResult AddProduct(Products products)
        {
            
            products.CreatedAt = DateTime.Now;
            products.UpdatedAt = DateTime.Now;
            products.UnitPrice =Convert.ToDecimal(products.UnitPrice);
            //TODO ISVALID
            if (!ModelState.IsValid)
            {
                
                return Json(false);
            }
            genericService.Add(products);
            return Json(true);

        }

        [HttpPost]
        public JsonResult UpdateProduct(Products p)
        {
            var theOne = genericService.GetById(p.ProductID);
            var getCreatedAt = theOne.CreatedAt;
            p.CreatedAt =getCreatedAt;
            p.UpdatedAt = DateTime.Now;
            //p.UnitPrice = Convert.ToDecimal(p.UnitPrice);

            if (!ModelState.IsValid)
            {

                return Json(false);
            }
            else
            {
                genericService.Update(p);
                return Json(true);
            }
        }
        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {

            
            genericService.DeleteById(id);
            return Json(true);

        }

        public JsonResult GetProduct(int id)
        {
            var data = genericService.GetById(id);
            
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}