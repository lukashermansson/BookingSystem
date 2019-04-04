using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace BookingSystem.Controllers
{
    public class TablesController : ApiController
    {
        private BookingDbContext db = new BookingDbContext();

        // GET: api/Tables
        public IQueryable<TableModel> GetTables()
        {
            return db.Tables;
        }

        // GET: api/Tables/5
        [ResponseType(typeof(TableModel))]
        public IHttpActionResult GetTableModel(int id)
        {
            TableModel tableModel = db.Tables.Find(id);
            if (tableModel == null)
            {
                return NotFound();
            }

            return Ok(tableModel);
        }

        // PUT: api/Tables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTableModel(int id, TableModel tableModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableModel.Id)
            {
                return BadRequest();
            }

            db.Entry(tableModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tables
        [ResponseType(typeof(TableModel))]
        public IHttpActionResult PostTableModel(TableModel tableModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tables.Add(tableModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tableModel.Id }, tableModel);
        }

        // DELETE: api/Tables/5
        [ResponseType(typeof(TableModel))]
        public IHttpActionResult DeleteTableModel(int id)
        {
            TableModel tableModel = db.Tables.Find(id);
            if (tableModel == null)
            {
                return NotFound();
            }

            db.Tables.Remove(tableModel);
            db.SaveChanges();

            return Ok(tableModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TableModelExists(int id)
        {
            return db.Tables.Count(e => e.Id == id) > 0;
        }
    }
}