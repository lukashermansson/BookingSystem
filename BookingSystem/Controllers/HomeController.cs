using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BookingDbContext db = new BookingDbContext();
            db.Configuration.ProxyCreationEnabled = false;
            var tablegroups = db.TableGroups
                .Include("Tables")
                .Include("Tables.Seats")
                .Include("Tables.Seats.codes");
            var model = new BookingViewModel { TableGroups = tablegroups.ToList() };
            return View(model);
        }
    }
}