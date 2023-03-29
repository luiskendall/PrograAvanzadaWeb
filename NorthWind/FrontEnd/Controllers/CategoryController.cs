using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        CategoryHelper categoryHelper;


        // GET: CategoryController
        public ActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            categoryHelper = new CategoryHelper(token);
            List<CategoryViewModel> lista = categoryHelper.GetAll();

            return View(lista);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            categoryHelper = new CategoryHelper();

            CategoryViewModel category = categoryHelper.Get(id);

            return View(category);

        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel cat)
        {
            try
            {
                categoryHelper = new CategoryHelper();

                CategoryViewModel category = categoryHelper.Create(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            categoryHelper = new CategoryHelper();

            CategoryViewModel category = categoryHelper.Get(id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel cat)
        {
            try
            {

                categoryHelper = new CategoryHelper();

                CategoryViewModel category = categoryHelper.Edit(cat);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        //// GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            categoryHelper = new CategoryHelper();

            CategoryViewModel category = categoryHelper.Get(id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                categoryHelper = new CategoryHelper();

                CategoryViewModel category = categoryHelper.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
