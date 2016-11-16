using BOL;
using DAL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BaseBranchesController : Controller
    {
        public IbranchRepositoryl branchesRepository;
        public StoreEntities _context;

        public BaseBranchesController()
        {
            this.branchesRepository = new BrancheRepository();
            this._context = new StoreEntities();
        }
    }
}
