using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseBillController:Controller
    {
        public IbillOrderRepository billRepository;
        public IorederRepository orederRepository;

        //public ICategoryRepository categoryRepository;
        //public StoreEntities _context;

        public BaseBillController()
        {
            this.billRepository = new BillRepository();
            this.orederRepository = new OrderRepository();
            //this._context = new StoreEntities();
        }
    }
}
