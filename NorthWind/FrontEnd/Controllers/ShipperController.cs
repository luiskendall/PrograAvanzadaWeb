using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ShipperController : Controller
    {

        ShipperHelper shipperHelper;

        // GET: ShipperController
        public ActionResult Index()
        {
            shipperHelper = new ShipperHelper();
            List<ShipperViewModel> list = shipperHelper.GetAll();
            return View(list);
        }

        // GET: ShipperController/Details/5
        public ActionResult Details(int id)
        {

            shipperHelper = new ShipperHelper();

            ShipperViewModel shipper = shipperHelper.Get(id);

            return View(shipper);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperViewModel ship)
        {
            try
            {
                shipperHelper = new ShipperHelper();

                ShipperViewModel shipper = shipperHelper.Create(ship);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            shipperHelper = new ShipperHelper();

            ShipperViewModel shipper = shipperHelper.Get(id);

            return View(shipper);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperViewModel ship)
        {
            try
            {
                shipperHelper = new ShipperHelper();

                ShipperViewModel shipper = shipperHelper.Edit(ship);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipperController/Delete/5
        public ActionResult Delete(int id)
        {
            shipperHelper = new ShipperHelper();

            ShipperViewModel shipper = shipperHelper.Get(id);
            return View(shipper);
        }

        // POST: ShipperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                shipperHelper = new ShipperHelper();

                ShipperViewModel shipper = shipperHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
