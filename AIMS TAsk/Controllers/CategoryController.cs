using BOL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class CategoryController : BaseCategoryController
    {
        // GET: Category
        public ActionResult Index()
        {
            var Categories = categoryRepository.GetCategories();
            return View(Categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = categoryRepository.GetCategoryById(id);
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.b_id = new SelectList(_context.Branches, "b_id", "b_name");
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Category category)
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
                    int newCount = categoryRepository.GetCategories().Count()+1;
                    
                    string path = Path.Combine(Server.MapPath("~/Images/Category/"), "Category" + newCount + "." + photoExtention);
                    string RelativePath = path.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);


                    category.c_photo = RelativePath;

                    categoryRepository.InsertCategory(category);

                    photo.Save(path);

                    TempData["InserMsg"] = "Category Added Successfully";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.b_id = new SelectList(_context.Branches, "b_id", "b_name");
            Category category = categoryRepository.GetCategoryById(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, Category category)
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

                    string path = Path.Combine(Server.MapPath("~/Images/Category/"), "Category" + category.c_id + "." + photoExtention);
                    string RelativePath = path.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);


                    category.c_photo = RelativePath;

                    categoryRepository.UpdateCategory(category);

                    photo.Save(path);

                    TempData["InserMsg"] = "Category Added Successfully";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {

            categoryRepository.DeleteCategory(id);
            return View();
        }



       


    }
}
