using BOL;
using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseItemController:Controller
    {
        public IitemRepository itemRepository;
        public ICategoryRepository categoryRepository;
        public StoreEntities _context;

        public BaseItemController()
        {
            this.itemRepository = new ItemRepository();
            this.categoryRepository = new CategoryRepository();
            this._context = new StoreEntities();
        }
    }
}
