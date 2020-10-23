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
            List<Staff> StaffList = businessContext.Staffs.ToList();
            return View(StaffList);
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
        }

             public ActionResult Details(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.Staffdetails = new SelectList(businessContext.Staffs, "StaffNo");
            return View(staff);
        }

        public ActionResult Edit(String id, Staff updatedBranches)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updatedBranches.StaffNo;
            staff.Fname = updatedBranches.Fname;
            staff.Lname = updatedBranches.Lname;
            staff.Position = updatedBranches.Position;
            staff.DOB = updatedBranches.DOB;
            staff.Salary = updatedBranches.Salary;
            staff.Branch_BranchNoRef = updatedBranches.Branch_BranchNoRef;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }

}