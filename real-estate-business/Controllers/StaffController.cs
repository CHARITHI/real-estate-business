using real_estate_business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_business.Controllers
{
    public class StaffController : Controller
    {
        private BuinessContext businessContext = new BuinessContext();

        // GET: Staff
        public ActionResult Index()
        {
            List<Staff> StaffDetails = businessContext.Staffs.ToList();
            return View(StaffDetails);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {

            {
                businessContext.Staffs.Add(staff);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }

             public ActionResult Details(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

    }
    }
}