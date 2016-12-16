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
    [RoutePrefix("api/Announcements")]
    public class AnnouncementsController : ApiController
    {
        private SmartParkContext db = new SmartParkContext();

        // GET: api/Announcements
        public IQueryable<Announcement> GetAnnoucements()
        {
            return db.Annoucements.Include(p => p.parking).Include(u => u.parking.user).Include(pl => pl.parking.place);
        }

        // GET: api/Announcements/user/IDUSER
        [Route("user/{idUser}")]
        public IQueryable<Announcement> GetAnnoucementsPseudo(int idUser)
        {
            return db.Annoucements.Include(p => p.parking).Include(u => u.parking.user).Include(pl => pl.parking.place).Where(p => p.parking.user.UserId == idUser);
        }

        // GET: api/Announcements/parking/IDPARKING
        [Route("parking/{idParking}")]
        public IQueryable<Announcement> GetAnnoucementsParking(int idParking)
        {
            return db.Annoucements.Include(p => p.parking).Include(u => u.parking.user).Include(pl => pl.parking.place).Where(u => u.parking.ParkingId == idParking);
        }

        // GET: api/Announcements/ID
        [Route("{id}")]
        public IQueryable<Announcement> GetAnnoucementId(int id)
        {
            return db.Annoucements.Include(p => p.parking).Include(u => u.parking.user).Include(pl => pl.parking.place).Where(a => a.AnnouncementId == id);
        }

        // PUT: api/Announcements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnnouncement(int id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.AnnouncementId)
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

            return CreatedAtRoute("DefaultApi", new { id = announcement.AnnouncementId }, announcement);
        }

        // DELETE: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> DeleteAnnouncement(int id)
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

        private bool AnnouncementExists(int id)
        {
            return db.Annoucements.Count(e => e.AnnouncementId == id) > 0;
        }
    }
}