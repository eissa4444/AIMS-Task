using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class OrderController : BaseOrderController
    {
        // GET: Order
        public ActionResult Index()
        {
            var orders = orederRepository.GetOrders();
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var warehouses = warehouseRepository.GetWarehouses();
            ViewBag.w_id = new SelectList(warehouses, "w_id", "w_name");
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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

        public JsonResult GetItems(int c_id)
        {
            var items = itemRepository.GetItems().Where(item => item.c_id == c_id);
            var itemsList = new SelectList(items, "it_id", "it_name");
            return Json(itemsList);
        }

        public JsonResult GetBranchs(int w_id)
        {
            var branchs = branchRepository.GetBranches().Where(warehouse => warehouse.w_id == w_id);
            var branchsList = new SelectList(branchs, "b_id", "b_name");
            return Json(branchsList);
        }

        public JsonResult GetCategories(int b_id)
        {
            var categories = categoryRepository.GetCategories().Where(cat => cat.b_id == b_id);
            var categoriesList = new SelectList(categories, "c_id", "c_name");
            return Json(categoriesList);
        }

        public JsonResult CalculatPriceTotal(int itId, int quantity, int remainig)
        {
            Item item = itemRepository.GetItemByID(itId);
            decimal price = item.price_a_discount;
            decimal remain = decimal.Parse(remainig.ToString());
            decimal totalPrice = (price * quantity) + remain;
            return Json(totalPrice);
        }

        public JsonResult CalculatPricePerUnit(int itId, int quantity)
        {
            Item item = itemRepository.GetItemByID(itId);
            decimal price = item.price_a_discount;
            decimal totalPrice = price * quantity;
            //var maxBillId = billOrderRepository.GetBillOrders().OrderByDescending(bill => bill.bill_id).FirstOrDefault().bill_id;
            return Json(totalPrice);
        }

        public JsonResult AddBill(decimal total_price)
        {
            Bill_orders bill = new Bill_orders();
            bill.bill_date = DateTime.Now.Date;
            bill.total_price = total_price;
            billOrderRepository.InsertBill(bill);
            var maxBillId = billOrderRepository.GetBills().OrderByDescending(theBill => theBill.bill_id).FirstOrDefault().bill_id;
            return Json(maxBillId);
        }

        public ActionResult inserOrders(List<Order> theOrders)
        {
            foreach (Order order in theOrders)
            {
                orederRepository.InsertOrder(order);
                Item item = itemRepository.GetItemByID(order.it_id);
                int itemQuantity = item.it_quantity;
                item.it_quantity = itemQuantity - order.quantity;
                itemRepository.UpdateItem(item);
            }
            return Json("ok");
        }



    }
}
