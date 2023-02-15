using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        CategoryHelper categoryHelper;

        public ActionResult Index()
        {
            categoryHelper = new CategoryHelper();
            List<CategoryModel> lista = categoryHelper.GetAll();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryModel category = categoryHelper.Get(id);

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                category = categoryHelper.Create(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET  
        public ActionResult Edit(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryModel category = categoryHelper.Get(id);
            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel category)
        {
            try
            {
                CategoryHelper categoryHelper = new CategoryHelper();
                category = categoryHelper.Edit(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET
        public ActionResult Delete(int id)
        {
            categoryHelper = new CategoryHelper();
            CategoryModel category = categoryHelper.Get(id);
            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryModel category)
        {
            try
            {
                categoryHelper = new CategoryHelper();
                categoryHelper.Delete(category.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

