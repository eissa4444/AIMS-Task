using BOL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class ItemController : BaseItemController
    {
        // GET: Item
        public ActionResult Index()
        {
            var items = itemRepository.GetItems();
            return View(items);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            Item item = itemRepository.GetItemByID(id);
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            var items = itemRepository.GetItems();
            ViewBag.b_id = new SelectList(_context.Branches, "b_id", "b_name");

            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Item item)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    // TODO: Add insert logic here

                    // to get the uploaded image from stream and set it in bitmap
                    Bitmap photo = new Bitmap(file.InputStream, false);

                    var imageType = file.ContentType;
                    string[] typeParameters = imageType.Split('/');
                    string photoExtention = typeParameters[1];
                    int newCount = itemRepository.GetItems().Count() + 1;

                    string path = Path.Combine(Server.MapPath("~/Images/Items/"), "item" + newCount + "." + photoExtention);
                    string RelativePath = path.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);


                    item.it_photo = RelativePath;

                    itemRepository.InsertItem(item);

                    photo.Save(path);

                    TempData["InserMsg"] = "item Added Successfully";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            Item item = itemRepository.GetItemByID(id);
            return View(item);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, Item item)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {


                    // to get the uploaded image from stream and set it in bitmap
                    Bitmap photo = new Bitmap(file.InputStream, false);

                    var imageType = file.ContentType;
                    string[] typeParameters = imageType.Split('/');
                    string photoExtention = typeParameters[1];

                    string path = Path.Combine(Server.MapPath("~/Images/Items/"), "Item" + item.it_id + "." + photoExtention);
                    string RelativePath = path.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);


                    item.it_photo = RelativePath;

                    itemRepository.UpdateItem(item);

                    photo.Save(path);

                    TempData["InserMsg"] = "item Edited Successfully";
                    return RedirectToAction("Index");   
                }
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            itemRepository.DeleteItem(id);
            return View();
        }


        public JsonResult GetCategories(int b_id)
        {
            var categories = categoryRepository.GetCategories().Where(cat => cat.b_id == b_id);
            var categoriesList = new SelectList(categories, "c_id", "c_name");
            return Json(categoriesList);
        }

    }
}
