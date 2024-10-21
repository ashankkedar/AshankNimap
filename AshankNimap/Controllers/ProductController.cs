using AshankNimap.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PagedList.Mvc;
using PagedList;
using System.Web;
using System.Web.Mvc;

namespace AshankNimap.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext dc = new StoreDbContext();

        public ViewResult DisplayProducts(int page = 1, int pageSize = 10)
        {
            var totalRecords = dc.Products.Count();

            var products = dc.Products.Include("Category").OrderBy(p => p.ProductId)
                             .Skip((page - 1) * pageSize).Take(pageSize).ToList();  //for pagination

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = totalRecords;

            return View(products);
        }

        public ViewResult ViewProduct(int ProductId)
        {
            Product product = dc.Products.Include("Category").Where(P => P.ProductId == ProductId).Single();
            return View(product);
        }
        [HttpGet]
        public ViewResult AddProduct()
        {
            var Categorylist = dc.Categories.ToList();
            ViewBag.CategoryList = new SelectList(Categorylist, "CategoryId", "CategoryName");
            
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                dc.Products.Add(product);
                dc.SaveChanges();
            }
            return RedirectToAction("DisplayProducts");

        }
        [HttpGet]
        public ViewResult EditProduct(int ProductId)
        {
            var Categorylist = dc.Categories.ToList();
            ViewBag.CategoryList = new SelectList(Categorylist, "CategoryId", "CategoryName");

            Product product = dc.Products.Find(ProductId);
            return View(product);
        }
        [HttpPost]
        public RedirectToRouteResult EditProduct(Product product)
        {
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
        [HttpGet]
        public ViewResult DeleteProduct(int ProductId)
        {
            var Categorylist = dc.Categories.ToList();
            ViewBag.CategoryList = new SelectList(Categorylist, "CategoryId", "CategoryName");

            Product product = dc.Products.Find(ProductId);
            return View(product);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteProduct(Product product)
        {
            dc.Entry(product).State = EntityState.Modified;
            dc.Products.Remove(product);    
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
    }
}