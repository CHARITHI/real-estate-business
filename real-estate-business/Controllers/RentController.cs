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

        public ActionResult Create(Rent rent)
        {
           
            {
                businessContext.Rents.Add(rent);
                businessContext.SaveChanges();
                return RedirectToAction("Index");
            }
      
            
        }
    }
}