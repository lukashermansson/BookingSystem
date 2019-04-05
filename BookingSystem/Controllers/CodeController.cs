using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSystem.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        [Authorize]
        public ActionResult Index()
        {
            BookingDbContext db = new BookingDbContext();
            var codes = db.Codes
                .Include("Seat")
                .ToList();
                
            return View(codes);
        }
        // GET: Code
        [Authorize]
        public ActionResult ToggleGiven(String id)
        {
            BookingDbContext db = new BookingDbContext();
            var code = db.Codes.Find(id);
            if(code != null)
            {
                code.IsGiven = !code.IsGiven;
            }
            db.SaveChanges();
            return null;
        }
    }
}