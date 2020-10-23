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

          return View();
        }

        [HttpPost]
        public ActionResult Create(Rent rent)
        {
           
            {
                businessContext.Rents.Add(rent);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }
      
          }

        public ActionResult Details(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Edit(String id)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.Rentdetails = new SelectList(businessContext.Rents, "PropertyNo");
            return View(rent);
        }

        public ActionResult Edit(String id, Rent updatedBranches)
        {
            Rent rent = businessContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updatedBranches.PropertyNo;
            rent.Street = updatedBranches.Street;
            rent.City = updatedBranches.City;
            rent.Ptype = updatedBranches.Ptype;
            rent.Rooms = updatedBranches.Rooms;
            rent.OwnerNoRef = updatedBranches.OwnerNoRef;
            rent.StaffNoRef = updatedBranches.StaffNoRef;
            rent.BranchNoRef = updatedBranches.BranchNoRef;
            rent.Rent1 = updatedBranches.Rent1;
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
            businessContext.Rents.Add(rent);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}