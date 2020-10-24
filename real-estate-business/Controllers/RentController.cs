using real_estate_business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_business.Controllers
{
    public class RentController : Controller
    {
        private BuinessContext businessContext = new BuinessContext();

        // GET: Rent
        public ActionResult Index()
        {
            List<Rent> RentList = businessContext.Rents.ToList();
            return View(RentList);
            
        }

        public ActionResult Create()
        {
            ViewBag.BranchDetails = businessContext.Branches;
            ViewBag.StaffDetails = businessContext.Staffs;
            ViewBag.OwnerDetails = businessContext.Owners;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Rent rent)
        {

            ViewBag.BranchDetails = businessContext.Branches;
            ViewBag.StaffDetails = businessContext.Staffs;
            ViewBag.OwnerDetails = businessContext.Owners;
            businessContext.Rents.Add(rent);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            
      
          }

        public ActionResult Details(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Edit(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.BranchDetails = new SelectList(businessContext.Branches, "BranchNo", "Street");
            ViewBag.StaffDetails = new SelectList(businessContext.Staffs, "StaffNo", "Fname");
            ViewBag.OwnerDetails = new SelectList(businessContext.Owners, "OwnerNo", "Fname");
            return View(rent);
        }
        [HttpPost]
        public ActionResult Edit(String id, Rent updatedRent)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updatedRent.PropertyNo;
            rent.Street = updatedRent.Street;
            rent.City = updatedRent.City;
            rent.Ptype = updatedRent.Ptype;
            rent.Rooms = updatedRent.Rooms;
            rent.OwnerNoRef = updatedRent.OwnerNoRef;
            rent.StaffNoRef = updatedRent.StaffNoRef;
            rent.BranchNoRef = updatedRent.BranchNoRef;
            rent.Rent1 = updatedRent.Rent1;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            businessContext.Rents.Remove(rent);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult city()
        {

            var Allcity = businessContext.Rents.ToList();


            int x = 0;
            int y = 0;


            foreach (Rent rent in Allcity)
            {
                x = x + 1;

            }

            string[] pos = new string[x];

            foreach (Rent rent in Allcity)
            {
                pos[y] = rent.City;
                y = y + 1;

            }

            var distinctArray = pos.Distinct().ToArray();
            ViewBag.city = distinctArray;


            return View();
        }

        public ActionResult citynw(string cty)
        {
            List<Rent> rent = businessContext.Rents.Where(x => x.City == cty).ToList();
            return View(rent);
        }


    }
}