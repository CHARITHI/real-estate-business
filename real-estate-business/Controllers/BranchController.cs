using real_estate_business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_business.Controllers
{
    public class BranchController : Controller
    {
        private BuinessContext businessContext = new BuinessContext();

        // GET: Branch
        public ActionResult Index()
        {
            List<Branch> BranchDetails = businessContext.Branches.ToList();
            return View(BranchDetails);
            
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {

            {
                businessContext.Branches.Add(branch);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }
         }

        public ActionResult Details(String id)
        {
            Branch branch = businessContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
    }
}