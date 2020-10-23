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
            List<Owner> OwnerDetails = businessContext.Owners.ToList();
            return View(OwnerDetails);
            
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Create(Owner owner)
        {

            {
                businessContext.Owners.Add(owner);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }


        }
    }
}