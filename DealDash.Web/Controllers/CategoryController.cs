using DealDash.Entities;
using DealDash.Services;
using DealDash.Web.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDash.Web.Controllers
{
    public class CategoryController : Controller
    {

        CategoriesService categoryService = new CategoriesService();

        public ActionResult Index()
        {
            CategoriesListingViewModel model = new CategoriesListingViewModel();
            model.categories = categoryService.GetAllCategories();

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = categoryService.GetCategoryByID(ID);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = categoryService.GetCategoryByID(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoryService.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}