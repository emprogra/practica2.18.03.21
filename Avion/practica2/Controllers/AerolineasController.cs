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
using practica2.Models;

namespace practica2.Controllers
{
    public class AerolineasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Aerolineas
        public IQueryable<Aerolinea> GetAerolineas()
        {
            return db.Aerolineas;
        }

        // GET: api/Aerolineas/5
        [ResponseType(typeof(Aerolinea))]
        public IHttpActionResult GetAerolinea(string id)
        {
            Aerolinea aerolinea = db.Aerolineas.Find(id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            return Ok(aerolinea);
        }

        // PUT: api/Aerolineas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAerolinea(string id, Aerolinea aerolinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aerolinea.Nombre)
            {
                return BadRequest();
            }

            db.Entry(aerolinea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerolineaExists(id))
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

        // POST: api/Aerolineas
        [ResponseType(typeof(Aerolinea))]
        public IHttpActionResult PostAerolinea(Aerolinea aerolinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aerolineas.Add(aerolinea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AerolineaExists(aerolinea.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aerolinea.Nombre }, aerolinea);
        }

        // DELETE: api/Aerolineas/5
        [ResponseType(typeof(Aerolinea))]
        public IHttpActionResult DeleteAerolinea(string id)
        {
            Aerolinea aerolinea = db.Aerolineas.Find(id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            db.Aerolineas.Remove(aerolinea);
            db.SaveChanges();

            return Ok(aerolinea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AerolineaExists(string id)
        {
            return db.Aerolineas.Count(e => e.Nombre == id) > 0;
        }
    }
}