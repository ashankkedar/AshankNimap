using AshankNimap.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AshankNimap.Controllers
{
    public class CategoryController : Controller
    {
        StoreDbContext dc=new StoreDbContext();

        public ViewResult DisplayCategories()
        {
            var categories = dc.Categories;
            return View(categories);
        }
        public ViewResult ViewCategory(int CategoryId)
        {
            var categories = dc.Categories.Find(CategoryId);
            return View(categories);
        }
        [HttpGet]
        public ViewResult AddCategory()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public RedirectToRouteResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                dc.Categories.Add(category);
                dc.SaveChanges();
            }
             return RedirectToAction("DisplayCategories");   
        }
        [HttpGet]
        public ViewResult EditCategory(int CategoryId)
        {
            Category category=dc.Categories.Find(CategoryId);
            return View(category);
        }
        [HttpPost]
        public RedirectToRouteResult EditCategory(Category category)
        {
            dc.Entry(category).State=EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");

        }
        [HttpGet]
        public ViewResult DeleteCategory(int CategoryId)
        {
            Category category= dc.Categories.Find(CategoryId);
            return View(category);
        }
        
        [HttpPost]
        public RedirectToRouteResult DeleteCategory(Category category)
        {
            dc.Entry(category).State = EntityState.Modified;
            dc.Categories.Remove(category);
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
    }
}