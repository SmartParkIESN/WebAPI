using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Model;

namespace SmartParkApi.Controllers
{
    public class ReportingsController : ApiController
    {
        private SmartParkContext db = new SmartParkContext();

        // GET: api/Reportings
        public IQueryable<Reporting> GetReportings()
        {
            return db.Reportings;
        }

        // GET: api/Reportings/5
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> GetReporting(long id)
        {
            Reporting reporting = await db.Reportings.FindAsync(id);
            if (reporting == null)
            {
                return NotFound();
            }

            return Ok(reporting);
        }

        // PUT: api/Reportings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReporting(long id, Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reporting.Id)
            {
                return BadRequest();
            }

            db.Entry(reporting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportingExists(id))
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

        // POST: api/Reportings
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> PostReporting(Reporting reporting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reportings.Add(reporting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reporting.Id }, reporting);
        }

        // DELETE: api/Reportings/5
        [ResponseType(typeof(Reporting))]
        public async Task<IHttpActionResult> DeleteReporting(long id)
        {
            Reporting reporting = await db.Reportings.FindAsync(id);
            if (reporting == null)
            {
                return NotFound();
            }

            db.Reportings.Remove(reporting);
            await db.SaveChangesAsync();

            return Ok(reporting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportingExists(long id)
        {
            return db.Reportings.Count(e => e.Id == id) > 0;
        }
    }
}