using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryDAL categoryDAL;

        //Constructor
        public CategoryController()
        {
            categoryDAL = new CategoryDALImpl(new Entities.NorthWindContext());
        }

        #region Convert Entity to Model
        private CategoryModel ConvertCategoryToModel(Category entity)
        {
            return new CategoryModel
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
            };
        }
        #endregion

        #region Convert Model to Entity
        private Category ConvertCategoryToEntity(CategoryModel model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description,
            };
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDAL.GetAll();

            List<CategoryModel> listCat = new List<CategoryModel>();

            foreach (var category in categories)
            {
                listCat.Add(ConvertCategoryToModel(category));
            }
            return new JsonResult(listCat);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category = categoryDAL.Get(id);

            /* 
            Una forma de hacerlo sin el método de ConvertCategoryToModel
            CategoryModel model = new CategoryModel
            {
                CategoryId = id,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            */
            return new JsonResult(ConvertCategoryToModel(category));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CategoryModel category)
        {
            Category entity = ConvertCategoryToEntity(category);
            categoryDAL.Add(entity);

            return new JsonResult(ConvertCategoryToModel(entity));
        }
        #endregion

        #region Actualizar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CategoryModel category)
        {
            categoryDAL.Update(ConvertCategoryToEntity(category));
            return new JsonResult(ConvertCategoryToEntity(category));
        }
        #endregion

        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new Category { CategoryId = id };
            categoryDAL.Remove(category);
            return new JsonResult(ConvertCategoryToModel(category));
        }
        #endregion
    }
}
