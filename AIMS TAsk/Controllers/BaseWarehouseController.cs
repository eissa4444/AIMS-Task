using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseWarehouseController : Controller
    {
        public IwarehouseRepository warehouseRepository;

        public BaseWarehouseController()
        {
            this.warehouseRepository = new WarehouseRepository();
        }

    }
}
