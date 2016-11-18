using BOL;
using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseCategoryController : Controller
    {
        public ICategoryRepository categoryRepository;
        public StoreEntities _context;

        public BaseCategoryController()
        {
            this.categoryRepository = new CategoryRepository();
            this._context = new StoreEntities();
        }
    }
}
