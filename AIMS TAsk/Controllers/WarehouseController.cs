using BOL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class WarehouseController : BaseWarehouseController
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            var warehouses = warehouseRepository.GetWarehouses();
            return View(warehouses);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int id)
        {
            Warehouse warehouse = warehouseRepository.GetWarehouseById(id);
            return View(warehouse);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        [HttpPost]
        public ActionResult Create(Warehouse warehouse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    warehouseRepository.InsertWarehouse(warehouse);
                    return RedirectToAction("Index");
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var warehouse = warehouseRepository.GetWarehouseById(id);
                return View(warehouse);
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }
            
        // POST: Warehouse/Edit/5
        [HttpPost]
        public ActionResult Edit(Warehouse warehouse)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    warehouseRepository.UpdateWarehouse(warehouse);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                warehouseRepository.DeleteWarehouse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
