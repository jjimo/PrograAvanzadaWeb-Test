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
    }
}

