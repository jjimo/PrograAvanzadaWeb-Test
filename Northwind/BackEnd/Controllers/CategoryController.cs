using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDAL categoryDAL;

        private CategoryModel Convertir(Category entity)
        {
            return new CategoryModel
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
        }

        private Category Convertir(CategoryModel model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description
            };
        }

        public CategoryController()
        {
            categoryDAL = new CategoryDALImpl(new Entities.Entities.NORTHWINDContext());
        }

        #region Consultar
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDAL.GetAll();
            List<CategoryModel> listaCategories = new List<CategoryModel>();

            foreach (var category in categories)
            {
                listaCategories.Add(Convertir(category));
            }


            return new JsonResult(categories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category;
            category = categoryDAL.Get(id);

            return new JsonResult(Convertir(category));
        }

        #endregion

        #region Agregar
        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] CategoryModel category)
        {
            categoryDAL.Add(Convertir(category));
            return new JsonResult(Convertir(category));
        }

        #endregion

        #region Modificar
        // PUT api/values/5
        [HttpPut]
        public JsonResult Put([FromBody] CategoryModel category)
        {
            categoryDAL.Update(Convertir(category));
            return new JsonResult(Convertir(category));
        }

        #endregion

        #region Eliminar
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new Category { CategoryId = id };
            categoryDAL.Remove(category);

            return new JsonResult(Convertir(category));
        }

        #endregion
    }
}

