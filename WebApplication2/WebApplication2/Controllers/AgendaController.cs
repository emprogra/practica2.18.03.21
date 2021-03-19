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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AgendaController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Agenda
        public IQueryable<Agenda> GetAgenda()
        {
            return db.Agenda;
        }

        // GET: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult GetAgenda(string id)
        {
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // PUT: api/Agenda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenda(string id, Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenda.Nombre)
            {
                return BadRequest();
            }

            db.Entry(agenda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
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

        // POST: api/Agenda
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult PostAgenda(Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agenda.Add(agenda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AgendaExists(agenda.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = agenda.Nombre }, agenda);
        }

        // DELETE: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult DeleteAgenda(string id)
        {
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            db.Agenda.Remove(agenda);
            db.SaveChanges();

            return Ok(agenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendaExists(string id)
        {
            return db.Agenda.Count(e => e.Nombre == id) > 0;
        }
    }
}