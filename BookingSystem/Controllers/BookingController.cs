using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingSystem.Controllers
{
    public class BookingController : ApiController
    {

        private BookingDbContext db = new BookingDbContext();

        
        public IHttpActionResult Post(SendBookingViewModel model)
        {
            if(model == null)
            {
                ModelState.AddModelError("error", "Model is empty");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "Dålig förfrågan");
                return BadRequest(ModelState);
            }
            //check if seat is booked
            var seat = db.Seats.Include("Codes").Where(p => p.Id == model.Seat).FirstOrDefault();
            if (seat == null)
            {
                ModelState.AddModelError("error", "Plats finns ej");
                return BadRequest(ModelState);
            }
            if (seat.IsBooked)
            {
                ModelState.AddModelError("error", "Plats redan bookad");
                return BadRequest(ModelState);
            }

            var code = db.Codes.Include("Seat").Where(p => p.Code == model.Code).FirstOrDefault();
            if (code == null)
            {
                //the code is used 
                ModelState.AddModelError("error", "Värdekoden existerar inte");
                return BadRequest(ModelState);
            }
            if (code.Seat != null)
            {
                //the code is used 
                ModelState.AddModelError("error", "Koden är andvänd");
                return BadRequest(ModelState);
            }


            seat.Name = model.Name;
            seat.Codes.Add(code);

            db.SaveChanges();




            return Ok(ModelState);
        }

    }
}
