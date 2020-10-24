using real_estate_business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_business.Controllers
{
    public class OwnerController : Controller
    {
        private BuinessContext businessContext = new BuinessContext();

        // GET: Owner
        public ActionResult Index()
        {
            List<Owner> OwnerList = businessContext.Owners.ToList();
            return View(OwnerList);
            
        }

        public ActionResult Create()
        {
            ViewBag.OwnerDetails = businessContext.Owners;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {

            {
                businessContext.Owners.Add(owner);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
             public ActionResult Details(String id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult Edit(String id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
           // ViewBag.Ownerdetails = new SelectList(businessContext.Owners, "OwnerNo");
            return View(owner);
        }

        public ActionResult Edit(String id, Owner updatedOwner)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.OwnerNo = updatedOwner.OwnerNo;
            owner.Fname = updatedOwner.Fname;
            owner.Lname = updatedOwner.Lname;
            owner.Address = updatedOwner.Address;
            owner.TelNo = updatedOwner.TelNo;
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOwner(String id)
        {
            Owner owner = businessContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            businessContext.Owners.Remove(owner);
            businessContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}