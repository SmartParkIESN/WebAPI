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
    public class AnnouncementsController : ApiController
    {
        private SmartParkContext db = new SmartParkContext();

        // GET: api/Announcements
        public IQueryable<Announcement> GetAnnoucements()
        {
            return db.Annoucements;
        }

        // GET: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> GetAnnouncement(long id)
        {
            Announcement announcement = await db.Annoucements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        // PUT: api/Announcements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnnouncement(long id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.Id)
            {
                return BadRequest();
            }

            db.Entry(announcement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id))
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

        // POST: api/Announcements
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> PostAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Annoucements.Add(announcement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = announcement.Id }, announcement);
        }

        // DELETE: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> DeleteAnnouncement(long id)
        {
            Announcement announcement = await db.Annoucements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }

            db.Annoucements.Remove(announcement);
            await db.SaveChangesAsync();

            return Ok(announcement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnouncementExists(long id)
        {
            return db.Annoucements.Count(e => e.Id == id) > 0;
        }
    }
}