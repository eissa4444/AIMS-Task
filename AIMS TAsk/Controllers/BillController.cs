using System.Linq;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BillController : BaseBillController
    {
        // GET: Bill
        public ActionResult Index()
        {
            var bills = billRepository.GetBills();
            return View(bills);
        }

        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            var ordersInBill = orederRepository.GetOrders().Where(o => o.bill_id == id);
            return View(ordersInBill);
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
