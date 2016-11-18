using BOL;
using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseItemController:Controller
    {
        public IitemRepository itemRepository;
        public StoreEntities _context;

        public BaseItemController()
        {
            this.itemRepository = new ItemRepository();
            this._context = new StoreEntities();
        }
    }
}
