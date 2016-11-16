using BOL;
using System.Web.Mvc;

namespace AIMS_TAsk.Controllers
{
    public class BranchesController : BaseBranchesController
    {
        // GET: Branches
        public ActionResult Index()
        {
            var branches = branchesRepository.GetBranches();
            return View(branches);
        }

        // GET: Branches/Details/5
        public ActionResult Details(int id)
        {
            Branch branch = branchesRepository.GetBranchByID(id);
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            ViewBag.w_id = new SelectList(_context.WareHouses, "w_id", "w_name");
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    branchesRepository.InsertBranch(branch);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.w_id = new SelectList(_context.WareHouses, "w_id", "w_name");
            Branch branch = branchesRepository.GetBranchByID(id);
            return View(branch);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    branchesRepository.UpdateBranch(branch);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int id)
        {
            branchesRepository.DeleteBranch(id);
            return View();
        }
    }
}
