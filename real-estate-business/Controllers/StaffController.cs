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
            ViewBag.BranchDetails = businessContext.Branches;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {

                 ViewBag.BranchDetails = businessContext.Branches;
                ViewBag.StaffDetails = businessContext.Staffs;
                businessContext.Staffs.Add(staff);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            
        }

         public ActionResult Details(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(businessContext.Branches, "BranchNo", " BranchNo");
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(String id, Staff updatedStaff)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updatedStaff.StaffNo;
            staff.Fname = updatedStaff.Fname;
            staff.Lname = updatedStaff.Lname;
            staff.Position = updatedStaff.Position;
            staff.DOB = updatedStaff.DOB;
            staff.Salary = updatedStaff.Salary;
            staff.Branch_BranchNoRef = updatedStaff.Branch_BranchNoRef;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Staff staff = businessContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            businessContext.Staffs.Remove(staff);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult position()
        {

            var AllStaff = businessContext.Staffs.ToList();

            

            int x = 0;
            int y = 0;


            foreach (Staff staff in AllStaff)
            {
                x = x + 1;

            }

            string[] pos = new string[x];

            foreach (Staff staff in AllStaff)
            {
                pos[y] = staff.Position;
                y = y + 1;

            }

            var distinctArray = pos.Distinct().ToArray();
            ViewBag.position = distinctArray;

            return View();
        }

        public ActionResult positionFind(string pos)
        {
            List<Staff> staff = businessContext.Staffs.Where(x => x.Position == pos).ToList();
            return View(staff);
        }

    }

}